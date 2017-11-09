using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenialO_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class RobotController : Controller
    {
        readonly HttpClient _httpClient;
        string move;

        public RobotController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<string> ConnnexionAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/connexion");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        [HttpGet]
        public async Task<string> EngineAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/engine");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        [HttpGet]
        public async Task<string> SynchronizeAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/synchronize");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        [HttpGet]
        public async Task<string> RightAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/right");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> LeftAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/left");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> FrontAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/front");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> BackAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("robot/back");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }
    }
}
