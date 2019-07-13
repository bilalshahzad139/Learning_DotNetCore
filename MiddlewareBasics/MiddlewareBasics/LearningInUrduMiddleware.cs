using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareBasics
{
    public class LearningInUrduMiddleware
    {
        private readonly RequestDelegate _MyNext;
        private readonly IHostingEnvironment _MyEnv;
        private ILogger _logger;
        public LearningInUrduMiddleware(RequestDelegate next, IHostingEnvironment env, ILogger<Startup> logger)
        {
            _MyNext = next;
            _MyEnv = env;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Start In Use middleware");
            await _MyNext(context);
            _logger.LogInformation("End In Use middleware");
        }
    }

    public static class MyWrapper
    {
        public static IApplicationBuilder UseLearningInUrdu(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LearningInUrduMiddleware>();
        }
    }
}
