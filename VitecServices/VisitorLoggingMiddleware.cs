using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VitecData;

namespace VitecServices
{
    public class VisitorLoggingMiddleware
    {
        private List<IpAddress> _ipAddresses;
        private readonly RequestDelegate _next;
        private string _connectionString = "http://vitecapi.azurewebsites.net/api/ipaddresses";

        public VisitorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            FillIpAddressList();
        }

        private void FillIpAddressList()
        {
            APICommunicationHelper.GetData(_connectionString, out _ipAddresses);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IpAddress connectionIpAddress = new IpAddress(context.Connection.RemoteIpAddress.MapToIPv6().ToString());
            if (!_ipAddresses.Contains(connectionIpAddress))
            {
                AddIpToList(connectionIpAddress);
            }
            
            await _next(context);
        }

        private void AddIpToList(IpAddress connectionIpAddress)
        {
            _ipAddresses.Add(connectionIpAddress);

            APICommunicationHelper.PutData(_connectionString, connectionIpAddress);
        }
    }

    public static class VisitorLoggingMiddleExtension
    {
        public static IApplicationBuilder UseVisitorLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VisitorLoggingMiddleware>();
        }
    }
}
