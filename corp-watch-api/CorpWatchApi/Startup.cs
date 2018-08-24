using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CorpWatchApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace CorpWatchApi
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
            /*services.AddDbContext<EmployeeContext>(opt =>
                opt.UseInMemoryDatabase("EmployeeList"));
            services.AddDbContext<JobContext>(opt =>
                opt.UseInMemoryDatabase("Job"));
*/
            services.AddCors();
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var Appconnection = Configuration["AppConnectionString"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(Appconnection);
                });

            var connection = Configuration["ConnectionString"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<UserContext>(options =>
                {
                    options.UseSqlServer(connection);
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc();
            
        }
    }
}
