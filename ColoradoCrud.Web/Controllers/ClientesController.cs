using ColoradoCrud.Web.Models;
using ColoradoCrud.Web.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ColoradoCrud.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientesController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient("apiClient");
            _httpContextAccessor= httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.TipoPessoas = Enum.GetNames(typeof(TipoPessoa)).ToList();
            ViewBag.UFs = Enum.GetNames(typeof(UFs)).ToList();
            return View();
        }
    
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.TipoPessoas = Enum.GetNames(typeof(TipoPessoa)).ToList();
            ViewBag.UFs = Enum.GetNames(typeof(UFs)).ToList();
            var cliente = await GetCliente(id);
            if (cliente != null)
            {
                return View(cliente);
              
            }
            return View("Error");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await GetCliente(id);
            if (cliente != null)
            {
                return View(cliente);

            }
            return View("Error");
        }


        private async Task<ClienteModel> GetCliente(int id)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["jwt"];
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"cliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var cliente = JsonSerializer.Deserialize<ClienteModel>(responseContent);
                return cliente;
            }
            return null;
        }


    }
}
