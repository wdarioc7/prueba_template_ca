using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace rdt_ms_template_netcore_ca.Infraestructure.Helpers
{
    public class EndpointCaller
    {
        private readonly HttpClient _httpClient;

        public EndpointCaller(string endpointUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(endpointUrl) };
        }

        public async Task<string> CallEndpointAsync(string endpointPath)
        {
            var response = await _httpClient.GetAsync(endpointPath);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

}
