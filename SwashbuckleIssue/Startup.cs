using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SwashbuckleIssue
{
    public class Startup
    {
        private static Action<MvcOptions> _postMvcOptionsConfiguration;
        public void ConfigureServices(IServiceCollection services)
        {
            IMvcCoreBuilder mvcBuilder = services.AddMvcCore();
            mvcBuilder.AddMvcOptions(options =>
            {
                if (_postMvcOptionsConfiguration == null)
                {
                    throw new Exception("This shouldn't be null. Looks like Startup.Configure(IApplication) wasn't called");
                }

                _postMvcOptionsConfiguration.Invoke(options);
            });
            mvcBuilder.AddApiExplorer();
            services.AddSwaggerGen(options =>
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

                options.SwaggerDoc(assemblyName, new OpenApiInfo
                {
                    Title = "Test API",
                    Version = "1"
                });

                string xmlCommentsDocumentPath = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");
                options.IncludeXmlComments(xmlCommentsDocumentPath);
                options.EnableAnnotations();
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            // Here we can retrieve any service and register it as a convention which is what we do in JADNC, but keeping the example simple here
            // var routingConvention = app.ApplicationServices.GetService<CustomRoutingConvention>();
            _postMvcOptionsConfiguration = options => options.Conventions.Insert(0, new CustomRoutingConvention());

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "docs/{documentName}/openapi.json";
            });

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
