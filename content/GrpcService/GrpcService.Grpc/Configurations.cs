using Grpc.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GrpcService.Grpc
{
    public static class Configurations
    {
        public static void UseGrpcDirectoryBrownser(this IApplicationBuilder application, string protosDirectory)
        {
            if (!Directory.Exists(protosDirectory))
            {
                throw new DirectoryNotFoundException(protosDirectory);
            }

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Clear();
            provider.Mappings[".proto"] = "text/plain";

            var staticFileOptions = new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(protosDirectory),
                RequestPath = "/proto",
                ContentTypeProvider = provider
            };

            application.UseStaticFiles(staticFileOptions);

            application.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = staticFileOptions.FileProvider,
                RequestPath = staticFileOptions.RequestPath
            });
        }

        public static void MapGrpcServices(this IEndpointRouteBuilder endpoint, Assembly assembly)
        {
            if (assembly is null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            var types = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType && x.BaseType.GetCustomAttribute<BindServiceMethodAttribute>() != null);

            foreach (var type in types)
            {
                var methodInfo = typeof(GrpcEndpointRouteBuilderExtensions).GetMethod("MapGrpcService");
                var method = methodInfo.MakeGenericMethod(type);
                method.Invoke(null, new[] { endpoint });
            }

        }
    }
}
