using com.devops.modelos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace com.devops.Aplicacion.Usuarios.Command
{

    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Usuario> _userManager;
        public LoginUserHandler(SignInManager<Usuario> signInManager, IConfiguration configuration, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Sid, user.Id),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.GivenName, $"{user.Nombre} {user.Apellido}")
                        };
                

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(
                           issuer: _configuration["Jwt:Issuer"],
                           audience: _configuration["Jwt:Audience"],
                           claims: claims,
                           expires: DateTime.Now.AddMinutes(30),
                           signingCredentials: credentials
               );
                var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                return jwt;
            }
            else
            {
                return "";
            }
        }
    }
}
