using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace RazorFunctionApp;



internal sealed class SampleFunction : IHttpTrigger
{
    [Function("SampleFunction")]
    public IActionResult EntryPoint(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest request)
    {
        const string viewPath = "Sample/Test";
        var http = request.HttpContext;
        var now = DateTimeOffset.Now;
        return this.ViewResult(http, viewPath, model: now);
    }
}