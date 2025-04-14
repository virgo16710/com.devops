using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.modelos
{
    public class Comuna
    {
        public Guid Id_comuna { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("region")]
        public Guid Id_region { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Region region { get; set; }
    }
}
