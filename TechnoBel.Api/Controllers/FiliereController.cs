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
using TechnoBel.Api.ViewModels;
using TechnoBel.Core.Interfaces;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiliereController : ControllerBase
    {
        private readonly IFiliereRepository _repo;
        private readonly IUserFiliereRepository _userFiliereRepo;
        private readonly IImageRepository _imageRepo;
        private readonly IFiliereImageRepository _filiereImageRepo;
        private readonly IMapper _mapper;

        public FiliereController(IFiliereRepository repo, IMapper mapper, IUserFiliereRepository userFiliereRepo, IImageRepository imageRepo, IFiliereImageRepository filiereImageRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _userFiliereRepo = userFiliereRepo;
            _imageRepo = imageRepo;
            _filiereImageRepo = filiereImageRepo;
        }
        // GET: api/Filiere
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<FiliereApi>))]
        public async Task<IActionResult> Get([FromQuery] GetFiliereParameters parameters)
        {
            try
            {
                IEnumerable<Filiere> entity = await _repo.Get(parameters.Name, parameters.Annee, parameters.Names);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<FiliereApi> entityApis = _mapper.Map<IEnumerable<FiliereApi>>(entity);
                foreach (FiliereApi e in entityApis)
                {
                    foreach (Filiere_ImageApi item in e.Filiere_Images)
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

        // GET api/Filiere/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(FiliereApi))]
        public async Task<IActionResult> Get(int id, [FromQuery] GetFiliereParameters parameters)
        {
            try
            {
                Filiere tmpentity = await _repo.GetOne(id, parameters.Name);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                FiliereApi tmpentityApi = _mapper.Map<FiliereApi>(tmpentity);

                foreach (Filiere_ImageApi item in tmpentityApi.Filiere_Images)
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

        // POST api/Filiere
        [HttpPost]
        [AuthRequired("Admin")]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] FiliereDTOApi value)
        {
            // n'est plus necessaire il verifie avant d'entrer dans le controller
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            FiliereDTO tmpentity = _mapper.Map<FiliereDTO>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Name))
                {
                    ModelState.AddModelError("la filière existe déjà.", "une filière avec le même nom existe déjà");
                    return BadRequest(ModelState);
                }
                else
                {
                    Filiere entity = new Filiere();

                    entity.Name = tmpentity.Name;
                    entity.Annee = DateTime.Now.Year;
                    entity.CreationDate = DateTime.Now;
                    Filiere entityCreated = await _repo.Post(entity);

                    if (tmpentity.MimeType != "" && tmpentity.File != null)
                    {
                        Image img = new Image();
                        img.MimeType = tmpentity.MimeType;
                        img.File = tmpentity.File;
                        Image i = await _imageRepo.Post(img);
                        Filiere_Image pi = new Filiere_Image();
                        pi.ImageId = i.Id;
                        pi.FiliereId = entityCreated.Id;
                        await _filiereImageRepo.Post(pi);
                    }

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
            return NoContent();
        }

        // PUT api/Filiere/5
        [HttpPut("{id}")]
        [AuthRequired("Admin")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] FiliereDTOApi value)
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
                FiliereDTO entity = _mapper.Map<FiliereDTO>(value);
                Filiere entityP = new Filiere();
                entityP.CreationDate = DateTime.Now;
                entityP.Name = entity.Name;
                entityP.Id = id;
                Filiere entityUpdate = await _repo.Put(id, entityP);

                if (entity.MimeType != "" && entity.File != null)
                {
                    Image img = new Image();
                        img.MimeType = entity.MimeType;
                        img.File = entity.File;
                        Image image = await _imageRepo.Post(img);
                        Filiere_Image pi = new Filiere_Image();
                        pi.ImageId = image.Id;
                        pi.FiliereId = entityUpdate.Id;
                        await _filiereImageRepo.Post(pi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return NoContent();
        }

        // DELETE api/Filiere/5
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
        public async Task<IActionResult> GetPagination([FromQuery] Parameters filiereParameters)
        {
            PagedList<Filiere> hobbies = await _repo.GetFiliere(filiereParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hobbies.MetaData));
            return Ok(hobbies);
        }
    }
}
