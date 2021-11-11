
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using E_commerce.Shared;

namespace CustomerSide.Services
{
    public static class HttpClientRegister
    {
        public static void AddCustomHttpClient(this IServiceCollection services, IConfiguration config)
        {
            var configureClient = new Action<IServiceProvider, HttpClient>(async (provider, client) =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var accessToken = await httpContextAccessor
                                            .HttpContext
                                            .GetTokenAsync(RequestConstants.ACCESS_TOKEN);

                client.BaseAddress = new Uri(config[ConfigurationConstants.BACK_END_ENDPOINT]);

                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue(RequestConstants.BEARER, accessToken);
            });

            services.AddHttpClient(ServiceConstants.BACK_END_NAMED_CLIENT, configureClient);
        }
    }
}