using ColoradoCrud.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ColoradoCrud.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IConfiguration _configuration;

        public AutenticacaoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("verify-token")]
        [Authorize] 
        public IActionResult VerifyToken()
        {        
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { message = "Token válido" });
            }
            return Unauthorized(new { message = "Token inválido ou expirado" });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
           
            if (string.IsNullOrWhiteSpace(model.Username))
            {
                ModelState.AddModelError("Username", "O campo Usuário é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("Password", "O campo Senha é obrigatório.");
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Login falhou. Verifique suas credenciais." });
            }

            using (var httpClient = new HttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(model);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{_configuration["ApiBaseUrl"]}/api/autenticacao/login", contentString);

                if (response.IsSuccessStatusCode)
                {
                     var responseContent = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenModel>(responseContent);
                    HttpContext.Response.Cookies.Append("jwt", tokenResponse.Token, new CookieOptions
                    {
                        HttpOnly = true, 
                        Secure = true, 
                        SameSite = SameSiteMode.Strict, 
                        Expires = DateTimeOffset.UtcNow.AddHours(1) 
                    });

                    return Json(new { success = true, token = tokenResponse.Token, redirectUrl = Url.Action("Index", "Home") });
                   
                }
                else
                {
                    return Json(new { success = false, message = "Login falhou. Verifique suas credenciais." });
                }
            }
        }



        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos");
            }

            using (var httpClient = new HttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(model);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{_configuration["ApiBaseUrl"]}/api/autenticacao/registrar", contentString);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { message = "Usuário registrado com sucesso!" });
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { message = responseContent });
                }
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {            
            Response.Cookies.Delete("jwt");

            return RedirectToAction("Login", "Autenticacao");
        }
    }
}
