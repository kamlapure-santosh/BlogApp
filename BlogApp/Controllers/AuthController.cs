using BlogApp.Service.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FirebaseAuthService _firebaseAuthService;

        public AuthController(FirebaseAuthService firebaseAuthService)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var token = await _firebaseAuthService.SignInWithEmailAndPasswordAsync(request.Email, request.Password);
            return Ok(new { Token = token });
        }
    }

    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
