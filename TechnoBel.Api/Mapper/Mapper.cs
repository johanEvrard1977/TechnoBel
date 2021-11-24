using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Api.Models;
using TechnoBel.Api.ViewModels;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;
using TechnoBel.ViewModels;

namespace TechnoBel.Api.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<LoginDto, ViewLoginApi>();
            CreateMap<RegisterDto, ViewRegisterApi>();
            CreateMap<User, UserApi>();
            CreateMap<Role, RoleApi>();
            CreateMap<Hobbies, HobbiesApi>();
            CreateMap<Hobby_Profile, Hobby_ProfileApi>();
            CreateMap<Image, ImageApi>();
            CreateMap<Dal.Models.Profile, ProfileApi>();
            CreateMap<Statut, StatutApi>();
            CreateMap<Technologie, TechnologieApi>();
            CreateMap<UserTechnologie, UserTechnologieApi>();
            CreateMap<Langue, LangueApi>();
            CreateMap<Filiere, FiliereApi>();
            CreateMap<UserFiliere, UserFiliereApi>();
            CreateMap<UserRole, UserRoleApi>();
            CreateMap<FiliereTechonologie, FiliereTechonologieApi>();
            CreateMap<CategorieDeProjet, CategorieDeProjetApi>();
            CreateMap<Projet, ProjetApi>();
            CreateMap<UserProjet, UserProjetApi>();
            CreateMap<Projet_Categorie, Projet_CategorieApi>();
            CreateMap<ProjetDTO, ProjetDTOApi>();
            CreateMap<ProjetImage, ProjetImageApi>();
            CreateMap<Badge, BadgeApi>();
            CreateMap<UserBadge, UserBadgeApi>();
            CreateMap<CurriculumVitae, CurriculumVitaeApi>();
            CreateMap<Filiere_Image, Filiere_ImageApi>();
            CreateMap<UserFiliere, UserFiliereApi>();
            CreateMap<Projet_Technologie, Projet_TechnologieApi>();
            CreateMap<FiliereDTO, FiliereDTOApi>();
            CreateMap<SoftSkills, SoftSkillsApi>();
            CreateMap<UserSoftSkills, UserSoftSkillsApi>();
            CreateMap<Profile_Image, Profile_ImageApi>();
            CreateMap<ProfileTechnologie, ProfileTechnologieApi>();
            CreateMap<Experience, ExperienceApi>();
            CreateMap<StagiaireDTO, StagiaireDTOApi>();

            // Resource to Domain
            CreateMap<ViewLoginApi, LoginDto>();
            CreateMap<ViewRegisterApi, RegisterDto>();
            CreateMap<UserApi, User>();
            CreateMap<RoleApi, Role>();
            CreateMap<HobbiesApi, Hobbies>();
            CreateMap<Hobby_ProfileApi, Hobby_Profile>();
            CreateMap<ImageApi, Image>();
            CreateMap<ProfileApi, Dal.Models.Profile>();
            CreateMap<StatutApi,Statut>();
            CreateMap<TechnologieApi, Technologie>();
            CreateMap<UserTechnologie, UserTechnologieApi>();
            CreateMap<LangueApi, Langue>();
            CreateMap<FiliereApi, Filiere>();
            CreateMap<UserFiliereApi, UserFiliere>();
            CreateMap<UserRoleApi, UserRole>();
            CreateMap<FiliereTechonologieApi, FiliereTechonologie>();
            CreateMap<CategorieDeProjetApi, CategorieDeProjet>();
            CreateMap<ProjetApi, Projet>();
            CreateMap<UserProjetApi, UserProjet>();
            CreateMap<Projet_CategorieApi, Projet_Categorie>();
            CreateMap<ProjetDTOApi, ProjetDTO>();
            CreateMap<ProjetImageApi, ProjetImage>();
            CreateMap<BadgeApi, Badge>();
            CreateMap<UserBadgeApi, UserBadge>();
            CreateMap<CurriculumVitaeApi, CurriculumVitae>();
            CreateMap<Filiere_ImageApi, Filiere_Image>();
            CreateMap<UserFiliereApi, UserFiliere>();
            CreateMap<Projet_TechnologieApi, Projet_Technologie>();
            CreateMap<FiliereDTOApi, FiliereDTO>();
            CreateMap<SoftSkillsApi, SoftSkills>();
            CreateMap<UserSoftSkillsApi, UserSoftSkills>();
            CreateMap<Profile_ImageApi, Profile_Image>();
            CreateMap<ProfileTechnologieApi, ProfileTechnologie>();
            CreateMap<ExperienceApi, Experience>();
            CreateMap<StagiaireDTOApi, StagiaireDTO>();
        }
    }
}

