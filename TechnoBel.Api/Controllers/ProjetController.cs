using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly IProjetRepository _repo;
        private readonly IUserProjetRepository _userProjetRepo;
        private readonly IProjetCategorieRepository _projetCatRepo;
        private readonly IImageRepository _imageRepo;
        private readonly IProjetImageRepository _projetImageRepo;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly DbSet<Projet_Categorie> _entities;

        public ProjetController(IProjetRepository repo, IMapper mapper, IUserProjetRepository userProjetRepo, IProjetCategorieRepository projetCatRepo, IImageRepository imageRepo, IProjetImageRepository projetImageRepo, Context context)
        {
            _repo = repo;
            _mapper = mapper;
            _userProjetRepo = userProjetRepo;
            _projetCatRepo = projetCatRepo;
            _imageRepo = imageRepo;
            _projetImageRepo = projetImageRepo;
            _context = context;
            _entities = _context.Set<Projet_Categorie>();
        }
        // GET: api/Projet
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<ProjetApi>))]
        public async Task<IActionResult> Get([FromQuery] GetProjetParameters parameters)
        {
            try
            {
                IEnumerable<Projet> entity = await _repo.Get(parameters.UserName, parameters.Name, parameters.Debut, parameters.Fin, parameters.Sujets, parameters.Names);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<ProjetApi> entityApis = _mapper.Map<IEnumerable<ProjetApi>>(entity);
                foreach(ProjetApi e in entityApis)
                {
                    foreach (ProjetImageApi item in e.ProjetImages)
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

        // GET api/Projet/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(ProjetApi))]
        public async Task<IActionResult> Get(int id, [FromQuery] GetProjetParameters parameters)
        {
            try
            {
                Projet tmpentity = await _repo.GetOne(id,parameters.Name);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                ProjetApi tmpentityApi = _mapper.Map<ProjetApi>(tmpentity);

                foreach (ProjetImageApi item in tmpentityApi.ProjetImages)
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

        // POST api/Projet
        [HttpPost]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] ProjetDTOApi value)
        {
            // n'est plus necessaire il verifie avant d'entrer dans le controller
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProjetDTO tmpentity = _mapper.Map<ProjetDTO>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Name))
                {
                    ModelState.AddModelError("le projet existe déjà.", "un projet avec le même nom existe déjà");
                    return BadRequest(ModelState);
                }
                else
                {
                    Projet entity = new Projet();

                    entity.Name = tmpentity.Name;
                    
                    entity.CreationDate = DateTime.Now;
                    Projet entityCreated = await _repo.Post(entity);

                    List<UserProjet> us = new List<UserProjet>();
                    foreach (var item in tmpentity.StagiaireId)
                    {
                        us.Add(new UserProjet { UserId = tmpentity.UserId, StagiaireId = item, ProjetId = entityCreated.Id });
                    }

                    await _context.AddRangeAsync(us);
                    await _context.SaveChangesAsync();


                    List<Projet_Categorie> pc = new List<Projet_Categorie>();

                    foreach (var item in tmpentity.CategorieId)
                    {
                        pc.Add(new Projet_Categorie { ProjetId = entityCreated.Id, CategorieId = item });
                    }
                    
                    await _context.AddRangeAsync(pc);
                    await _context.SaveChangesAsync();

                    if (tmpentity.MimeType != null && tmpentity.File != null)
                    {
                        Image img = new Image();
                        img.MimeType = tmpentity.MimeType;
                        img.File = tmpentity.File;
                        Image i = await _imageRepo.Post(img);
                        ProjetImage pi = new ProjetImage();
                        pi.ImageId = i.Id;
                        pi.ProjetId = entityCreated.Id;
                        await _projetImageRepo.Post(pi);
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

        // PUT api/Projet/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] ProjetDTOApi value)
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
                ProjetDTO entity = _mapper.Map<ProjetDTO>(value);
                Projet entityP = new Projet();
                entityP.CreationDate = DateTime.Now;
                entityP.Name = entity.Name;
                entityP.Id = id;
                Projet entityUpdate = await _repo.Put(id, entityP);

                foreach (var item in entity.CategorieId)
                {
                    entityUpdate = await _repo.GetByStagiaireId(item);
                    if (entityUpdate == null)
                    {
                        UserProjet us = new UserProjet();

                        us.UserId = entity.UserId;
                        us.StagiaireId = item;
                        us.ProjetId = entityP.Id;
                        await _userProjetRepo.Post(us);
                    }
                }


                if (entity.MimeType != "" && entity.File != null)
                {
                    Image img = new Image();
                        img.MimeType = entity.MimeType;
                        img.File = entity.File;
                        Image image = await _imageRepo.Post(img);
                        ProjetImage pi = new ProjetImage();
                        pi.ImageId = image.Id;
                        pi.ProjetId = entityUpdate.Id;
                        await _projetImageRepo.Post(pi);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return NoContent();
        }

        // DELETE api/Projet/5
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
        public async Task<IActionResult> GetPagination([FromQuery] Parameters HobbyParameters)
        {
            PagedList<Projet> hobbies = await _repo.GetProjets(HobbyParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hobbies.MetaData));
            return Ok(hobbies);
        }
    }
}