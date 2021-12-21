using illShop.Shared.BasicServices;
using illShop.Shared.Dto.DtosRelatedIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace illShop.Server.Controllers.Identity
{
    [Route("LoginHandler")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenExtension _tokenExtension;
        public LoginController(UserManager<IdentityUser> userManager, ITokenExtension tokenExtension)
        {
            _userManager = userManager;
            _tokenExtension = tokenExtension;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto loginModelDto)
        {
            var user = await _userManager.FindByNameAsync(loginModelDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModelDto.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _tokenExtension.GetSigningCredentials();
            var claims = _tokenExtension.GetClaims(user);
            var tokenOptions = _tokenExtension.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
    }
}
