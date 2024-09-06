using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ColoradoCrud.Web.Models;
using System.Security.Claims;
using System.Net.Http.Headers;

public class TelefonesController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public TelefonesController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClientFactory.CreateClient("apiClient");
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Create()
    {      
        return View();
    }


    [Route("Telefones/Edit/{numero}")]
    public async Task<IActionResult> Edit(string numero)
    {
        var telefone = await GetTelefone(numero);
        if (telefone != null)
        {
            return View(telefone);
        }
        return View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TelefoneModel telefone)
    {
        if (!ModelState.IsValid)
        {
            return View(telefone);
        }

        var response = await _httpClient.PutAsJsonAsync($"telefone/{telefone.NumeroTelefone}", telefone);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View("Error");
    }

    [Route("Telefones/Delete/{numero}")]
    public async Task<IActionResult> Delete(string numero)
    {
        var telefone = await GetTelefone(numero);
        if (telefone != null)
        {
            return View(telefone);
        }
        return View("Error");
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string numero)
    {
        var response = await _httpClient.DeleteAsync($"telefone/{numero}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View("Error");
    }

    private async Task<TelefoneModel> GetTelefone(string numero)
    {
        var token = _httpContextAccessor.HttpContext?.Request.Cookies["jwt"];
        if (string.IsNullOrEmpty(token))
        {
            return null;
        }
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.GetAsync($"telefone/{numero}");
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var telefone = JsonSerializer.Deserialize<TelefoneModel>(responseContent);
            return telefone;
        }
        return null;
    }
}
