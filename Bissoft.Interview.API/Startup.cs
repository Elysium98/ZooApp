using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Bissoft.Interview.Data;
using Microsoft.EntityFrameworkCore;
using Bissoft.Interview.Data.Implementation;
using Bissoft.Interview.Data.Interfaces;
using System.Reflection;
using Bissoft.Interview.Services;
using Bissoft.Interview.Services.Interfaces;
using Bissoft.Interview.Services.Implementation;

namespace Bissoft.Interview.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IZooKeeperRepository, ZooKeeperRepository>();
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IZooKeeperService, ZooKeeperService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetAssembly(typeof(BussinesProfile)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(PresentationProfile)));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bissoft.Interview.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bissoft.Interview.API v1"));
            }

            app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
