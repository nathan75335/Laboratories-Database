using FrontEndForWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.Net;

namespace FrontEndForWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5085/books/");
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        [HttpGet]
        public async Task<IActionResult> Index(int size = 50, int numberOfPage = 1)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, "getbooks");

            req.Headers.Add("size", $"{size}");
            req.Headers.Add("numberOfPage", $"{numberOfPage}");

            var response = await _client.SendAsync(req);
            
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return View();
            }

            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonSerializer.Deserialize<ModelPageable<BookDto>>(content, _options);

            return createdCompany is not null ? View(createdCompany.Data) : View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDto book)
        {
            book.Genres = new List<GenreDto>
            {
                new GenreDto
                {
					Name = "Romance",
					Description = "Parle de romance"
				},
                new GenreDto
                {
					Name = "Drama",
					Description = "Talks about Drama"
				}
            };
            var bookSerialized = JsonSerializer.Serialize(book);
            var requestContent = new StringContent(bookSerialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("add", requestContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonSerializer.Deserialize<BookDto>(content, _options);

            return Redirect("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}