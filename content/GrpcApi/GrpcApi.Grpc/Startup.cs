using GrpcApi.Application;
using GrpcApi.Infrastructure;

using Herald.Observability.Jaeger.Configurations;
using Herald.Web.Swagger;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.IO;

namespace GrpcApi.Grpc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFeatures(Configuration);
#if (sqs || kafka || rabbitmq || azure)
            services.AddQueues(Configuration);
#endif
#if (!noexternalapi)
            services.AddWebServices(Configuration);
#endif
#if (postgre || mysql || sqlserver)
            services.AddRepositories(Configuration);
#endif
            services.AddGrpc();
            services.AddGrpcHttpApi();
            services.AddSwagger();
            services.AddGrpcSwagger();
            services.AddGrpcReflection();
            services.AddJaegerTracing(setup => Configuration.GetSection("JaegerOptions").Bind(setup));
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseDeveloperExceptionPage();
                app.UseGrpcDirectoryBrownser(Path.Combine(Env.ContentRootPath, "Protos"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapGrpcApis(typeof(Startup).Assembly);
            });
        }
    }
}
