using Microsoft.AspNetCore.Identity;

namespace com.devops.modelos
{
    public class Usuario:IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }
        public Guid ComunaId { get; set; }
    }
}
