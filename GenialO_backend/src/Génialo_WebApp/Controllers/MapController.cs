using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenialO_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        readonly HttpClient _httpClient;
        string map;

        public MapController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("Mapping")]
        public async Task<string> MappingAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("map/mapping");

            if (response.IsSuccessStatusCode)
            {
                map = await response.Content.ReadAsStringAsync();
            }
            return map;
        }

        [HttpGet("GiveAll")]
        public async Task<string> GiveAllAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("map/giveAll");

            if (response.IsSuccessStatusCode)
            {
                map = await response.Content.ReadAsStringAsync();
            }
            return map;
        }

        [HttpGet("Choose")]
        public async Task<string> ChooseAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("map/choose");

            if (response.IsSuccessStatusCode)
            {
                map = await response.Content.ReadAsStringAsync();
            }
            return map;
        }

        [HttpGet("Delete")]
        public async Task<string> DeleteAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("map/delete");

            if (response.IsSuccessStatusCode)
            {
                map = await response.Content.ReadAsStringAsync();
            }
            return map;
        }

        [HttpGet("Point")]
        public async Task<string> PointAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("map/point");

            if (response.IsSuccessStatusCode)
            {
                map = await response.Content.ReadAsStringAsync();
            }
            return map;
        }

        [HttpGet("GoTo")]
        public async Task<string> GoToAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("map/goTo");

            if (response.IsSuccessStatusCode)
            {
                map = await response.Content.ReadAsStringAsync();
            }
            return map;
        }
    }
}
