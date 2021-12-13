using curriculum.Business;
using curriculum.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
