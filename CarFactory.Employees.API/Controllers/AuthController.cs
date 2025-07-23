using CarFactory.Employees.SharedLibrary.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CarFactory.Employees.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly KeycloakConfiguration _keycloakConfiguration;

        public AuthController(IHttpClientFactory httpClientFactory, IOptions<KeycloakConfiguration> options)
        {
            _httpClient = httpClientFactory.CreateClient() ?? throw new ArgumentNullException(nameof(_httpClient));
            _keycloakConfiguration = options.Value;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] LoginRequest request)
        {
            var parameters = new Dictionary<string, string>
            {
                ["client_id"] = _keycloakConfiguration.ClientId,
                ["client_secret"] = _keycloakConfiguration.ClientSecret,
                ["grant_type"] = _keycloakConfiguration.GrantType,
                ["username"] = request.Username,
                ["password"] = request.Password
            };

            var content = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync("http://localhost:8080/realms/myrealm/protocol/openid-connect/token", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            return Content(responseBody, "application/json");
        }
    }
}

public class LoginRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
