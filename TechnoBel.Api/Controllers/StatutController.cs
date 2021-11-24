using AutoMapper;
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
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutController : ControllerBase
    {
        private readonly IStatutRepository _repo;
        private readonly IMapper _mapper;

        public StatutController(IStatutRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Statut
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<StatutApi>))]
        public async Task<IActionResult> Get([FromQuery] GetStatutParameters parameters)
        {
            try
            {
                IEnumerable<Statut> entity = await _repo.Get(parameters.Name);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<StatutApi> entityApis = _mapper.Map<IEnumerable<StatutApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Statut/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(StatutApi))]
        public async Task<IActionResult> Get(int id, [FromQuery] GetStatutParameters parameters)
        {
            try
            {
                Statut tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                StatutApi tmpentityApi = _mapper.Map<StatutApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Statut
        [HttpPost]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] StatutApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Statut tmpentity = _mapper.Map<Statut>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Id))
                {
                    ModelState.AddModelError("le Statut existe déjà.", "un statut avec le même nom existe déjà");
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

        // PUT api/Statut/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] StatutApi value)
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
                Statut entity = _mapper.Map<Statut>(value);
                entity.CreationDate = DateTime.Now;
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Statut/5
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
        public async Task<IActionResult> GetPagination([FromQuery] Parameters StatutParameters)
        {
            var Statuts = await _repo.GetStatuts(StatutParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(Statuts.MetaData));
            return Ok(Statuts);
        }
    }
}