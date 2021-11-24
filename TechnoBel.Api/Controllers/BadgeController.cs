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
using TechnoBel.Core.Repositories;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BadgeController : ControllerBase
    {
        private readonly IBadgeRepository _repo;
        private readonly IMapper _mapper;

        public BadgeController(IBadgeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Badge
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<BadgeApi>))]
        public async Task<IActionResult> Get([FromQuery] GetBadgeParameters parameters)
        {
            try
            {
                IEnumerable<Badge> entity = await _repo.Get(parameters.Name);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<BadgeApi> entityApis = _mapper.Map<IEnumerable<BadgeApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Badge/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(BadgeApi))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Badge tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                BadgeApi tmpentityApi = _mapper.Map<BadgeApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Badge
        [HttpPost]
        [AuthRequired("Admin")]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] BadgeApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Badge tmpentity = _mapper.Map<Badge>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Id))
                {
                    ModelState.AddModelError("le badge existe déjà.", "un badge avec le même nom existe déjà");
                    return BadRequest(ModelState);
                }
                else
                {
                    tmpentity.CreationDate = DateTime.Now;
                    await _repo.Post(tmpentity);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
            return NoContent();
        }

        // PUT api/Badge/5
        [HttpPut("{id}")]
        [AuthRequired("Admin")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] BadgeApi value)
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
                Badge entity = _mapper.Map<Badge>(value);
                entity.CreationDate = DateTime.Now;
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Badge/5
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
            PagedList<Badge> filieres = await _repo.GetBadge(Parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(filieres.MetaData));
            return Ok(filieres);
        }
    }
}