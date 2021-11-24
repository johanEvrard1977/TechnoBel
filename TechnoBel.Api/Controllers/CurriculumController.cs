using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;
using TechnoBel.Api.ViewModels;
using TechnoBel.Core.Interfaces;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumRepository _repo;
        private readonly IMapper _mapper;

        public CurriculumController(ICurriculumRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Curriculum
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<CurriculumVitaeApi>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<CurriculumVitae> entity = await _repo.Get();
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<CVDTOApi> entityApis = entity.Select(e => new CVDTOApi
                {
                    Id = e.Id,
                    ImageUrl = "/api/Curriculum/" + e.Id
                });

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Curriculum/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(CurriculumVitaeApi))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                CurriculumVitae tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                return File(tmpentity.File, tmpentity.MimeType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Curriculum
        [HttpPost]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] CurriculumVitaeApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CurriculumVitae tmpentity = _mapper.Map<CurriculumVitae>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                await _repo.Post(tmpentity);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
            return NoContent();
        }

        // PUT api/Curriculum/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] CurriculumVitaeApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != value.Id || value == null)
            {
                return BadRequest();
            }

            try
            {
                CurriculumVitae entity = _mapper.Map<CurriculumVitae>(value);
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Curriculum/5
        [HttpDelete("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetPagination")]
        public async Task<IActionResult> GetPagination([FromQuery] Parameters Parameters)
        {
            PagedList<CurriculumVitae> filieres = await _repo.GetImages(Parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(filieres.MetaData));
            return Ok(filieres);
        }
    }
}