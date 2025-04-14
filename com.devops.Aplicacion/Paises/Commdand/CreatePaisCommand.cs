using MediatR;

namespace com.devops.Aplicacion.Paises.Commdand
{
    public class CreatePaisCommand : IRequest
    {
        public string Nombre { get; set; }
    }
}
