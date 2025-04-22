using MediatR;

namespace com.devops.Aplicacion.Usuarios.Command
{
    public class CreateRolCommand: IRequest<bool>
    {
        public string Nombre { get; set; }
    }
}
