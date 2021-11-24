using AutoMapper;
using GestionContact.Helpers;
using GestionContact.ParametersModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechnoBel.Api.Models;
using TechnoBel.Api.ViewModels;
using TechnoBel.Core.Interfaces;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;
using TechnoBel.ViewModels;

namespace TechnoBel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IUserRoleRepository _userRoleRepo;
        private readonly IUserFiliereRepository _userFiliereRepo;
        private readonly IProfileRepository _profileRepo;
        private readonly IRoleRepository _repoRole;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserBadgeRepository _userBadgeRepo;
        private readonly ICurriculumRepository _cvRepo;
        private readonly IExperienceRepository _expRepo;
        private readonly IProfileRepository _profilRepo;
        private readonly IImageRepository _imgRepo;
        private readonly IProfile_ImageRepository _proImgRepo;

        public UserController(IUserRepository repo, IMapper mapper, ITokenService tokenService, IUserRoleRepository userRoleRepo, IUserFiliereRepository userFiliereRepo, IProfileRepository profileRepo, IRoleRepository repoRole, IUserBadgeRepository userBadgeRepo, ICurriculumRepository cvRepo, IExperienceRepository expRepo, IProfileRepository profilRepo, IImageRepository imgRepo, IProfile_ImageRepository proImgRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _tokenService = tokenService;
            _userRoleRepo = userRoleRepo;
            _userFiliereRepo = userFiliereRepo;
            _profileRepo = profileRepo;
            _repoRole = repoRole;
            _userBadgeRepo = userBadgeRepo;
            _cvRepo = cvRepo;
            _expRepo = expRepo;
            _profilRepo = profilRepo;
            _imgRepo = imgRepo;
            _proImgRepo = proImgRepo;
        }
        // GET: api/User
        [HttpGet]
        [AuthRequired("Admin")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<UserApi>))]
        public async Task<IActionResult> Get([FromQuery] GetUserParameters parameters)
        {
            try
            {
                IEnumerable<User> user = await _repo.Get(parameters.Lastname, parameters.role, parameters.Email, parameters.Names);
                if (user == null)
                {
                    return NotFound();
                }
                IEnumerable<UserApi> userApis = _mapper.Map<IEnumerable<UserApi>>(user);

                return Ok(userApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        [AuthRequired("Admin")]
        [Produces("application/json", Type = typeof(UserApi))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                User tmpUser = await _repo.GetOne(id, true);
                if (tmpUser == null)
                {
                    return NotFound();
                }
                UserApi tmpUserApi = _mapper.Map<User, UserApi>(tmpUser);

                tmpUserApi.Password = "*******";
                return Ok(tmpUserApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(int id, [FromBody] UserApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!id.Equals(value.Id))
            {
                return BadRequest();
            }

            User tmpUser = await _repo.GetOne(id);
            if (tmpUser == null)
            {
                return NotFound();
            }

            try
            {
                UserApi user = _mapper.Map<UserApi>(tmpUser);
                var hasher = new PasswordHasher<User>();
                user.Password = hasher.HashPassword(null, value.Password);
                user.CreationDate = DateTime.Now;
                await _repo.Put(user.Id,tmpUser);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        [Produces("application/json", Type = null)]
        [AuthRequired("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        [HttpGet]
        [Route("GetPagination")]
        public async Task<IActionResult> GetPagination([FromQuery] Parameters productParameters)
        {
            var users = await _repo.GetUsers(productParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(users.MetaData));
            return Ok(users);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] ViewLoginApi loginDTOApi)
        {
            LoginDto loginDTO = _mapper.Map<ViewLoginApi, LoginDto>(loginDTOApi);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User tmpUser = await _repo.GetByMail(loginDTO.Email);
            
            
            
            if (!(tmpUser is null))
            {
                var result = new PasswordHasher<User>().VerifyHashedPassword(tmpUser, tmpUser.Password, loginDTO.Password);
                if(result == PasswordVerificationResult.Success)
                {
                    LoginSuccessDto loginSuccessDTO = new LoginSuccessDto();

                    loginSuccessDTO.Id = tmpUser.Id;
                    loginSuccessDTO.UserName = tmpUser.UserName;
                    loginSuccessDTO.Email = tmpUser.Email;
                    loginSuccessDTO.Role = tmpUser.UserRoles.FirstOrDefault().Role.Name;
                    loginSuccessDTO.Token = _tokenService.GenerateToken(loginSuccessDTO);
                    loginSuccessDTO.ExpirationDate = DateTime.Now.AddDays(1);

                    return Ok(loginSuccessDTO);
                }
                return BadRequest("mot de passe ou email incorrect");
            }
            return BadRequest("mot de passe ou email incorrect");
        }
        [HttpPost]
        [Route("register")]
        [AuthRequired("Admin")]
        public async Task<IActionResult> Register([FromBody] ViewRegisterApi modelApi)
        {
            RegisterDto model = _mapper.Map<ViewRegisterApi, RegisterDto>(modelApi);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            bool tmpUser = await _repo.UserMailExists(model.Email);
            if (!tmpUser)
            {
                User createdUser = new User();
                createdUser.Email = model.Email;
                createdUser.UserName = model.UserName;
                createdUser.FirstName = model.Firstname;
                createdUser.LastName = model.Lastname;
                createdUser.Password = new PasswordHasher<User>().HashPassword(createdUser, model.Password);
                createdUser.CreationDate = DateTime.Now;

                User u = await _repo.Post(createdUser);

                UserRole us = new UserRole();
                us.RoleId = model.RoleId;
                us.UserId = u.Id;
                await _userRoleRepo.Post(us);

                UserFiliere uf = new UserFiliere();
                uf.FiliereId = model.FiliereId;
                uf.UserId = u.Id;
                await _userFiliereRepo.Post(uf);

                Role r = await _repoRole.GetOne(model.RoleId);
                if(r.Name == "Stagiaire")
                {
                    Dal.Models.Profile p = new Dal.Models.Profile();
                    p.Firstname = u.FirstName;
                    p.LastName = u.LastName;
                    p.UserName = u.UserName;
                    p.StatutId = 1;
                    p.UserId = u.Id;
                    p.CreationDate = DateTime.Now;
                    await _profileRepo.Post(p);
                }
                return NoContent();
            }
            else
            {
                ModelState.AddModelError("Already existing user", "A user with this email/username already exists.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("registerStagiaire")]
        [AuthRequired("Admin")]
        public async Task<IActionResult> RegisterStagiaire([FromBody] StagiaireDTOApi modelApi)
        {
            StagiaireDTO model = _mapper.Map<StagiaireDTOApi, StagiaireDTO>(modelApi);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            bool tmpUser = await _repo.UserMailExists(model.UserName);
            if (!tmpUser)
            {

                CurriculumVitae cv = new CurriculumVitae();
                cv.File = model.FileCv;
                cv.MimeType = model.MimeTypeCv;
                CurriculumVitae curriculum = await _cvRepo.Post(cv);


                User createdUser = new User();
                createdUser.UserName = model.UserName;
                createdUser.CurriculumVitaeId = curriculum.Id;
                createdUser.CreationDate = DateTime.Now;

                User u = await _repo.Post(createdUser);


                Experience exp = new Experience();
                exp.Titre = model.Titre;
                exp.UserId = u.Id;
                exp.Description = model.Description;
                await _expRepo.Post(exp);

                UserRole us = new UserRole();
                us.RoleId = 2;
                us.UserId = u.Id;
                await _userRoleRepo.Post(us);

                Dal.Models.Profile p = new Dal.Models.Profile();
                    p.UserName = u.UserName;
                    p.StatutId = 1;
                    p.UserId = u.Id;
                    p.Description = model.Description;
                    p.CreationDate = DateTime.Now;
                Dal.Models.Profile pro = await _profileRepo.Post(p);
                Image img = new Image();
                img.File = model.File;
                img.MimeType = model.MimeType;

                Image i = await _imgRepo.Post(img);

                Profile_Image pi = new Profile_Image();
                pi.ImageId = i.Id;
                pi.ProfileId = pro.Id;
                await _proImgRepo.Post(pi);
                

                UserBadge ub = new UserBadge();
                ub.UserId = u.Id;
                ub.BadgeId = model.BadgeId;
                await _userBadgeRepo.Post(ub);


                return NoContent();
            }
            else
            {
                ModelState.AddModelError("Already existing stagiaire", "A stagiaire with this username already exists.");
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("available/{email}")]
        public async Task<IActionResult> Available(string Email)
        {
            var swAvailable = await _repo.UserMailExists(Email);
            return Ok(!swAvailable);
        }
    }
}