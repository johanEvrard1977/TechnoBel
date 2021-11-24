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
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _repo;
        private readonly IMapper _mapper;

        public ProfileController(IProfileRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Profile
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<ProfileApi>))]
        public async Task<IActionResult> Get([FromQuery] GetProfileParameters parameters)
        {
            try
            {
                IEnumerable<Dal.Models.Profile> entity = await _repo.Get(parameters.Name, parameters.FirstName, parameters.Email, parameters.Names);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<ProfileApi> entityApis = _mapper.Map<IEnumerable<ProfileApi>>(entity);
                foreach (ProfileApi e in entityApis)
                {
                    foreach (Profile_ImageApi item in e.ProfileImages)
                    {
                        item.ImageUri = "/api/image/" + item.ImageId;
                    }
                }
                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Profile/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(ProfileApi))]
        public async Task<IActionResult> Get(int id, [FromQuery] GetProfileParameters parameters)
        {
            try
            {
                Dal.Models.Profile tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                ProfileApi tmpentityApi = _mapper.Map<ProfileApi>(tmpentity);
                foreach (Profile_ImageApi item in tmpentityApi.ProfileImages)
                {
                    item.ImageUri = "/api/image/" + item.ImageId;
                }
                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Profile/5
        [HttpGet]
        [Route("ByUserId/{userId}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(ProfileApi))]
        public async Task<IActionResult> GetByUserId(int userId, [FromQuery] GetProfileParameters parameters)
        {
            try
            {
                Dal.Models.Profile tmpentity = await _repo.GetByUserId(userId);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                ProfileApi tmpentityApi = _mapper.Map<ProfileApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Profile
        [HttpPost]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] ProfileApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Dal.Models.Profile tmpentity = _mapper.Map<Dal.Models.Profile>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Id))
                {
                    ModelState.AddModelError("le profile existe déjà.", "un profil avec le même nom existe déjà");
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

        // PUT api/Profile/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] ProfileApi value)
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
                Dal.Models.Profile entity = _mapper.Map<Dal.Models.Profile>(value);
                entity.CreationDate = DateTime.Now;
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Profile/5
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
        public async Task<IActionResult> GetPagination([FromQuery] Parameters ProfileParameters)
        {
            var profiles = await _repo.GetProfiles(ProfileParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(profiles.MetaData));
            return Ok(profiles);
        }
    }
}
