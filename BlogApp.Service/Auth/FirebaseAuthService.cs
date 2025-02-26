using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlogApp.Core.Dtos;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Service.Auth
{
    public class FirebaseAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IUserService _userService;
        public FirebaseAuthService(HttpClient httpClient, IConfiguration configuration, IUserService userService)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Firebase:ApiKey"];
            _userService = userService;
        }

        public async Task<FirebaseAuthServiceResponse> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            email = "newazureacc1@gmail.com";
            password = "pwd1231";
            var requestBody = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={_apiKey}", content);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<JsonElement>(responseBody);

            var idToken = responseData.GetProperty("idToken").GetString();
            var userEmail = responseData.GetProperty("email").GetString();
            var userId = 0;
            if (userEmail != null)
            {
                // Check if the user exists in the database
                var user = await _userService.GetUserByEmailAsync(userEmail);
                if (user == null)
                {
                    // Create a new user
                    var newUser = new AppUserDto
                    {
                        Email = userEmail,
                        Username = userEmail.Split('@')[0], // Example: use the part before '@' as the username,

                    };
                    userId = await _userService.CreateUserAsync(newUser);
                }
                else
                {
                    userId = user.Id;
                }
            }

            return new FirebaseAuthServiceResponse { IdToken = idToken ?? string.Empty, UserId = userId };
        }
    }
}
