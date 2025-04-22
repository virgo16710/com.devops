using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.Aplicacion.Usuarios.Command
{
    
    public class CreateRolHandler : IRequestHandler<CreateRolCommand,bool>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateRolHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            // Implementar la lógica para crear un rol aquí
            // Por ejemplo, guardar el rol en la base de datos
            var result = await _roleManager.CreateAsync(new IdentityRole(request.Nombre));
            return result.Succeeded;
        }
    }
}
