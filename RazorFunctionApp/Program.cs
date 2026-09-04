using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using RazorClassLibrary;

var builder = FunctionsApplication.CreateBuilder(args);
builder.ConfigureFunctionsWebApplication();
builder.Services.AddRazorEngine();
builder.Build().Run();
