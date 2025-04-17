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
    public class CreateUserCommand : IRequest<IdentityResult>
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Guid comunaId { get; set; }
    }
}
