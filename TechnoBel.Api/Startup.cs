using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Seed;
using TechnoBel.Dal.Models;
using Microsoft.AspNetCore.Identity;
using TechnoBel.Core.Repositories;
using TechnoBel.Core.Interfaces;
using GestionContact.Helpers;

namespace TechnoBel.Api
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ajout des cors afin de pouvoir communiquer entre domaines différents
            services.AddCors(policy =>
            {
                policy.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:4200").AllowAnyHeader()
                                                                      .AllowAnyMethod()
                                                                      .AllowAnyOrigin()
                                                                      .WithExposedHeaders("X-Pagination");
                    });
            });
            services.AddAutoMapper(typeof(Startup));
            //configure database
            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TechnoBel"), b => b.MigrationsAssembly("TechnoBel.Api")));
            //configure identity
            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<Context>()
            //    .AddDefaultTokenProviders();

            //configure repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IHobbyRepository, HobbyRepository>();
            services.AddTransient<IStatutRepository, StatutRepository>();
            services.AddTransient<ITechnologieRepository, TechnologieRepository>();
            services.AddTransient<ILangueRepository, LangueRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IFiliereRepository, FiliereRepository>();
            services.AddTransient<IUserFiliereRepository, UserFiliereRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IProjetRepository, ProjetRepository>();
            services.AddTransient<ICategorieDeProjetRepository, CategorieDeProjetRepository>();
            services.AddTransient<IUserProjetRepository, UserProjetRepository>();
            services.AddTransient<IProjetCategorieRepository, ProjetCategorieRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IProjetImageRepository, ProjetImageRepository>();
            services.AddTransient<IBadgeRepository, BadgeRepository>();
            services.AddTransient<IUserBadgeRepository, UserBadgeRepository>();
            services.AddTransient<ICurriculumRepository, CurriculumRepository>();
            services.AddTransient<IFiliereImageRepository, FiliereImageRepository>();
            services.AddTransient<IProjetTechnologieRepository, ProjetTechnologieRepository>();
            services.AddTransient<ISoftSkillsRepository, SoftSkillsRepository>();
            services.AddTransient<IUserSoftSkillsRepository, UserSoftSkillsRepository>();
            services.AddTransient<IExperienceRepository, ExperienceRepository>();
            services.AddTransient<IProfile_ImageRepository, Profile_ImageRepository>();

            //service jwt Token
            services.AddSingleton<ITokenService, TokenService>();

            //pagination
            services.AddTransient<IParametreRepository, ParametreRepository>();

            // AddNewtonsoftJson empêche les dépendances circulaires lors des Include et ThenInclude
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnoBel.Api", Version = "v1" });
                OpenApiSecurityScheme securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnoBel.Api v1"));
            }

            //initialise le Seed afin d'avoir des données de tests dans la base de donnée
            Seed.Initialize(serviceProvider);
            app.UseRouting();
            // utilisation des cors avec le nom "MyAllowSpecificOrigins"
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
