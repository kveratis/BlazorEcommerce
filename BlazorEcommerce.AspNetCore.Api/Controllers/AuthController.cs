using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.AspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<ProductController> _logger;

        public AuthController(IAuthService authService, ILogger<ProductController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister userRegister)
        {
            var response = await _authService.Register(new User()
            {
                Email = userRegister.Email.ToLower()
            }, userRegister.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }

    public sealed class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 15)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
