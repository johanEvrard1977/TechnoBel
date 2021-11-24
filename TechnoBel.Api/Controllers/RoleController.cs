using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;
using TechnoBel.Api.ParametersModels;
using TechnoBel.Core.Interfaces;
using TechnoBel.Dal.Models;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Role
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<RoleApi>))]
        public async Task<IActionResult> Get([FromQuery] GetRoleParameters parameters)
        {
            try
            {
                IEnumerable<Role> entity = await _repo.Get(parameters.Name);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<RoleApi> entityApis = _mapper.Map<IEnumerable<RoleApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Role/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(RoleApi))]
        public async Task<IActionResult> Get(int id, [FromQuery] GetRoleParameters parameters)
        {
            try
            {
                Role tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                RoleApi tmpentityApi = _mapper.Map<RoleApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Role
        [HttpPost]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] RoleApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Role tmpentity = _mapper.Map<Role>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Id.ToString()))
                {
                    ModelState.AddModelError("le role existe déjà.", "un role avec le même nom existe déjà");
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

        // PUT api/Role/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] RoleApi value)
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
                Role entity = _mapper.Map<Role>(value);
                entity.CreationDate = DateTime.Now;
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Role/5
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
    }
}