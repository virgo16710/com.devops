using com.devops.modelos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.Aplicacion.Usuarios.Command
{
    public class CreateUserHandler :IRequestHandler<CreateUserCommand,IdentityResult>
    {
        private readonly UserManager<Usuario> _userManager;
        public CreateUserHandler(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario
            {
                Nombre = request.nombre,
                Apellido = request.apellido,
                UserName = request.userName,
                Email = request.email,
                ComunaId = request.comunaId,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Estado = true
            };
            var result = await _userManager.CreateAsync(user, request.password);
            return result;
        }
    }
}
