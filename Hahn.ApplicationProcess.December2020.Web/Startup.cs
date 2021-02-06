using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data;
using DAO = Hahn.ApplicationProcess.December2020.Data.DAO;
using Hahn.ApplicationProcess.December2020.Domain;
using DTO = Hahn.ApplicationProcess.December2020.Domain.DTO;
using Hahn.ApplicationProcess.December2020.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation;
using Hahn.ApplicationProcess.December2020.Domain.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using FluentValidation.AspNetCore;

namespace Hahn.ApplicationProcess.December2020.Web
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
            ConfigureDataServices(services);

            ConfigureDomainServices(services);

            services.AddControllers()
                .AddFluentValidation(fluentValidator => fluentValidator.RegisterValidatorsFromAssemblyContaining<ApplicantValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicationProcess.December2020.Web", Version = "v1" });
            });
        }

        private void ConfigureDomainServices(IServiceCollection services) 
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationProcessMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddHttpClient();
            services.AddScoped<IApplicationProcessService, ApplicationProcessService>();
        }

        private void ConfigureDataServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseInMemoryDatabase("ApplicationProcess"));

            services.AddScoped<IRepository<DAO.Applicant>, Repository<DAO.Applicant>>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicationProcess.December2020.Web v1"));
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
