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
            HttpResponseMessage response = await _httpClient.GetAsync("Move/right");

            if(response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> LeftAsync(bool value)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Move/left?value=" + value);

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> FrontAsync(bool value)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Move/front?value=" + value);

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }

        public async Task<string> BackAsync(bool value)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Move/back?value=" + value);

            if (response.IsSuccessStatusCode)
            {
                move = await response.Content.ReadAsStringAsync();
            }
            return move;
        }
    }
}
