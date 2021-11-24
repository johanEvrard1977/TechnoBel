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
    public class CategorieDeProjetController : ControllerBase
    {
        private readonly ICategorieDeProjetRepository _repo;
        private readonly IMapper _mapper;

        public CategorieDeProjetController(ICategorieDeProjetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/CategorieDeProjet
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<CategorieDeProjetApi>))]
        public async Task<IActionResult> Get([FromQuery] GetCategorieDeProjetParameters parameters)
        {
            try
            {
                IEnumerable<CategorieDeProjet> entity = await _repo.Get(parameters.Name);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<CategorieDeProjetApi> entityApis = _mapper.Map<IEnumerable<CategorieDeProjetApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/CategorieDeProjet/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(CategorieDeProjetApi))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                CategorieDeProjet tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                CategorieDeProjetApi tmpentityApi = _mapper.Map<CategorieDeProjetApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/CategorieDeProjet
        [HttpPost]
        [AuthRequired("Admin")]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] CategorieDeProjetApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CategorieDeProjet tmpentity = _mapper.Map<CategorieDeProjet>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                if (await _repo.AlreadyExists(tmpentity.Id))
                {
                    ModelState.AddModelError("la Categorie existe déjà.", "une Categorie avec le même nom existe déjà");
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

        // PUT api/CategorieDeProjet/5
        [HttpPut("{id}")]
        [AuthRequired("Admin")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] CategorieDeProjetApi value)
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
                CategorieDeProjet entity = _mapper.Map<CategorieDeProjet>(value);
                entity.CreationDate = DateTime.Now;
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/CategorieDeProjet/5
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
            PagedList<CategorieDeProjet> filieres = await _repo.GetCategorieDeProjet(Parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(filieres.MetaData));
            return Ok(filieres);
        }
    }
}