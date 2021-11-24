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
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyRepository _repo;
        private readonly IMapper _mapper;

        public HobbyController(IHobbyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Hobby
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<HobbiesApi>))]
        public async Task<IActionResult> Get([FromQuery] GetHobbyParameters parameters)
        {
            try
            {
                IEnumerable<Hobbies> entity = await _repo.Get(parameters.Name);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<HobbiesApi> entityApis = _mapper.Map<IEnumerable<HobbiesApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Hobby/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(HobbiesApi))]
        public async Task<IActionResult> Get(int id, [FromQuery] GetHobbyParameters parameters)
        {
            try
            {
                Hobbies tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                HobbiesApi tmpentityApi = _mapper.Map<HobbiesApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Hobby
        [HttpPost]
        [AuthRequired("Admin")]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] HobbiesApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Hobbies tmpentity = _mapper.Map<Hobbies>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Id))
                {
                    ModelState.AddModelError("le hobby existe déjà.", "un hobby avec le même nom existe déjà");
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

        // PUT api/Hobby/5
        [HttpPut("{id}")]
        [AuthRequired("Admin")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] HobbiesApi value)
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
                Hobbies entity = _mapper.Map<Hobbies>(value);
                entity.CreationDate = DateTime.Now;
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Hobby/5
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
        public async Task<IActionResult> GetPagination([FromQuery] Parameters HobbyParameters)
        {
            PagedList<Hobbies> hobbies = await _repo.GetHobbies(HobbyParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hobbies.MetaData));
            return Ok(hobbies);
        }
    }
}