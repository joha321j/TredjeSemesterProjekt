using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VitecServices
{
    public class VisitorLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public VisitorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
