using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RSLab.BL.Services;
using RSLab.DAL.Internal;
using RSLab.DAL.Repositories;
using Serilog;
using System.Reflection;
using Contexts = RSLab.DAL.Internal.Implementation;
using Repositories = RSLab.DAL.Repositories.Implementation;
using Services = RSLab.BL.Services.Implementation;

namespace RSLab.WepAPI
{
    public class Startup
    {
        private readonly string _swaggerDocVersion;
        private readonly string _swaggerDocTitle;
        private readonly string _swaggerDocDescription;
        private readonly string _swaggerDocCompany;
        private readonly string _swaggerDocCopyright;

        public IConfiguration Configuration { get; }
        public bool SwaggerIsEnabled => Configuration.GetValue("SwaggerIsEnabled", false);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var attributes = Assembly.GetExecutingAssembly().CustomAttributes;

            _swaggerDocVersion =
                ReflectionHelper.AttributeReader<AssemblyVersionAttribute>(attributes) ??
                ReflectionHelper.AttributeReader<AssemblyFileVersionAttribute>(attributes);
            _swaggerDocTitle = ReflectionHelper.AttributeReader<AssemblyTitleAttribute>(attributes);
            _swaggerDocDescription = ReflectionHelper.AttributeReader<AssemblyDescriptionAttribute>(attributes);
            _swaggerDocCompany = ReflectionHelper.AttributeReader<AssemblyCompanyAttribute>(attributes);
            _swaggerDocCopyright = ReflectionHelper.AttributeReader<AssemblyCopyrightAttribute>(attributes);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose: true);
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddMvc()
                .AddMvcOptions(t => t.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            if (SwaggerIsEnabled)
            {
                services.AddSwaggerDocument(config =>
                {
                    config.PostProcess = document =>
                    {
                        document.Info.Version = _swaggerDocVersion;
                        document.Info.Title = _swaggerDocTitle;
                        document.Info.Description = _swaggerDocDescription;
                        document.Info.Contact = new NSwag.OpenApiContact
                        {
                            Name = _swaggerDocCompany,
                            Email = string.Empty,
                            Url = "https://github.com/Alex-fbr/"
                        };
                        document.Info.License = new NSwag.OpenApiLicense
                        {
                            Name = _swaggerDocCopyright
                        };
                    };
                });
            }

            services.AddMemoryCache();

            //// регистрация всех контекстов, репозиториев и сервисов
            services.AddScoped<IStockDbContext, Contexts.StockDbContext>();
            services.AddScoped<IStockRepository, Repositories.StockRepository>();
            services.AddScoped<IMarketService, Services.MarketService>();

            services.AddMvc().AddControllersAsServices();
        }

        // Этот метод вызывается средой выполнения. Этот метод используется для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSerilogRequestLogging();

            if (SwaggerIsEnabled)
            {
                // Register the Swagger generator and the Swagger UI middlewares
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
