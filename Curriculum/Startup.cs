using curriculum.Business;
using curriculum.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Incidences
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ICurriculumBz, CurriculumBz>();
            services.AddTransient<IUserBz, UserBz>();
            services.AddTransient<ICurriculumData, CurriculumData>();
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<ICredentialsData, CredentialsData>();
            services.AddTransient<ICredentialsBz, CredentialsBz>();
            services.AddTransient<IPasswordRecoveryData, PasswordRecoveryData>();
            services.AddTransient<IPasswordRecoveryBz, PasswordRecoveryBz>();
            services.AddTransient<IContentData, ContentData>();
            services.AddTransient<IContentBz, ContentBz>();
            services.AddTransient<ISubContentBz, SubContentBz>();
            services.AddTransient<ISubContentData, SubContentData>();
            services.AddTransient<IExperienceBz, ExperienceBz>();
            services.AddTransient<IExperienceData, ExperienceData>();
            services.AddTransient<IContractBz, ContractBz>();
            services.AddTransient<IContractData, ContractData>();
            services.AddTransient<IProjectData, ProjectData>();
            services.AddTransient<IProjectBz, ProjectBz>();
            services.AddTransient<IDescriptionData, DescriptionData>();
            services.AddTransient<IDescriptionBz, DescriptionBz>();
            services.AddTransient<ITrainingData, TrainingData>();
            services.AddTransient<ITrainingBz, TrainingBz>();
            services.AddTransient<ILanguageData, LanguageData>();
            services.AddTransient<ILanguageBz, LanguageBz>();
            services.AddTransient<ILanguageLevelData, LanguageLevelData>();
            services.AddTransient<ILanguageLevelBz, LanguageLevelBz>();
            // CONFIGURACIÓN DEL SERVICIO DE AUTENTICACIÓN JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
                        )
                    };
                });
            services.AddDbContext<CurriculumContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                )
            );
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // AÑADIMOS EL MIDDLEWARE DE AUTENTICACIÓN
            // DE USUARIOS AL PIPELINE DE ASP.NET CORE
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
