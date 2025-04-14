using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.modelos
{
    public class Pais
    {
        [Key]
        public Guid Id_pais { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual ICollection<Region> Regiones { get; set; }
    }
}
