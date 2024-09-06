using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ColoradoCrud.Web.Models;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class TiposTelefoneController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TiposTelefoneController(IHttpClientFactory httpClientFactory , IHttpContextAccessor httpContextAccessor)
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

 
    public async Task<IActionResult> Edit(int id)
    {
        var tipoTelefone = await GetTipotelefone(id);
        if (tipoTelefone != null)
        {
            return View(tipoTelefone);
        }
        return View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TipoTelefoneModel tipoTelefone)
    {
        if (!ModelState.IsValid)
        {
            return View(tipoTelefone);
        }

        var response = await _httpClient.PutAsJsonAsync($"tipotelefone/{tipoTelefone.CodigoTipoTelefone}", tipoTelefone);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View("Error");
    }

  
    public async Task<IActionResult> Delete(int id)
    {

        var tipoTelefone  = await GetTipotelefone(id) ;
        if (tipoTelefone != null)
        {
            return View(tipoTelefone);
        }
        return View("Error");
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _httpClient.DeleteAsync($"tipotelefone/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View("Error");
    }
    private async Task<TipoTelefoneModel> GetTipotelefone(int id)
    {
        var token = _httpContextAccessor.HttpContext?.Request.Cookies["jwt"];
        if (string.IsNullOrEmpty(token))
        {        
            return null;
        }
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.GetAsync($"tipotelefone/{id}");
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var tipoTelefone = JsonSerializer.Deserialize<TipoTelefoneModel>(responseContent);
            return tipoTelefone;
        }
        return null;
    }
}
