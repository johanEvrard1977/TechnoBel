using AutoMapper;
using GestionContact.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;
using TechnoBel.Api.ParametersModels;
using TechnoBel.Core.Interfaces;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _repo;
        private readonly IMapper _mapper;

        public ExperienceController(IExperienceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Experience
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<ExperienceApi>))]
        public async Task<IActionResult> Get([FromQuery] GetExperienceParameters parameters)
        {
            try
            {
                IEnumerable<Experience> entity = await _repo.Get(parameters.Titre);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<ExperienceApi> entityApis = _mapper.Map<IEnumerable<ExperienceApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Experience/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(ExperienceApi))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Experience tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                ExperienceApi tmpentityApi = _mapper.Map<ExperienceApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Experience
        [HttpPost]
        [AuthRequired("Admin")]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] ExperienceApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Experience tmpentity = _mapper.Map<Experience>(value);

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

        // PUT api/Experience/5
        [HttpPut("{id}")]
        [AuthRequired("Admin")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] ExperienceApi value)
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
                Experience entity = _mapper.Map<Experience>(value);
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Experience/5
        [HttpDelete("{id}")]
        [AuthRequired("Admin")]
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
            PagedList<Experience> filieres = await _repo.GetExperience(Parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(filieres.MetaData));
            return Ok(filieres);
        }
    }
}