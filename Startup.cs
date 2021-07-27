using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CadastrosGerais.Common;
using CadastrosGerais.IoC;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CadastrosGerais.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CadastrosGerais.Controllers.Common;

namespace CadastrosGerais
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;

            Base.TIPOBANCO = _config["Settings:TIPOBANCO"];
            switch (Base.TIPOBANCO)
            {
                case "SQL":
                    Base.STRINGCONEXAO = _config["ConnectionString:SQL"];
                    break;
                case "ORACLE":
                    Base.STRINGCONEXAO = _config["ConnectionString:ORACLE"];
                    break;
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            // Injecting repositories dependencies
            RepositoryInjector.RegisterRepositories(services);

         
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsAllowAll");

            app.UseHttpsRedirection();
            var supportedCultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR"),
                new CultureInfo("en-AU"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("es-ES"),
                new CultureInfo("es-MX"),
                new CultureInfo("es"),
                new CultureInfo("fr-FR"),
                new CultureInfo("fr"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseSwagger(option => {
                option.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro Generico");
                option.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
