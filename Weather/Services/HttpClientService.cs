using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Entities;
using Weather.Interfaces;
using System.Text.Json;


namespace Weather.Services
{
    public class HttpClientService : IHttpClientService
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<City> Cities { get; private set; }

        public HttpClientService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            Configuration = configuration;
        }

        public async Task OnGet(string query)
        {
            string url = String.Format(Configuration.GetValue<string>("SearchURL"), query);

            var request = new HttpRequestMessage(HttpMethod.Get,url);
            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                Cities = await JsonSerializer.DeserializeAsync
                    <IEnumerable<City>>(responseStream);
            }
            else
            {
                //GetBranchesError = true;
                Cities = Array.Empty<City>();
            }
        }
    }
}
