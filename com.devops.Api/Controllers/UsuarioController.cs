using com.devops.Aplicacion.Usuarios.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.devops.API.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("/registrar")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.Succeeded)
            {
                return BadRequest("No se guado");
            }
            return Ok(new { message = "Usuario creado exitosamente" });
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _mediator.Send(new LoginUserCommand
            {
                UserName = userName,
                Password = password
            });
            if (String.IsNullOrEmpty(result))
            {
                return BadRequest("Usuario no registrado");
            }
            return Ok(new { message = result });
        }
        [HttpPost("/CrearRol")]
        [Authorize]
        public async Task<IActionResult> CreateRole([FromBody]string roleName)
        {
            var result = await _mediator.Send(new CreateRolCommand
            {
                Nombre = roleName
            });
            if (!result)
            {
                return BadRequest("No se guado");
            }
            return Ok(new { message = "Rol creado exitosamente" });
        }
    }
}