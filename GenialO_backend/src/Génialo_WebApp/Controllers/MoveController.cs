using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenialO_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class MoveController : Controller
    {
        readonly HttpClient _httpClient;
        string move;

        public MoveController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<string> RightAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("move/right");

            if(response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> LeftAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("move/left");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> FrontAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("move/front");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> BackAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("move/back");

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }
    }
}
