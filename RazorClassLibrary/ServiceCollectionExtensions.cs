using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RazorClassLibrary;



public static class ServiceCollectionExtensions
{
    extension(IServiceCollection @this)
    {
        public IMvcCoreBuilder AddRazorEngine()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            var builder = @this.AddMvcCore();
            builder.AddViews();
            builder.AddRazorViewEngine();
            builder.AddApplicationPart(thisAssembly);
            return builder;
        }
    }
}
