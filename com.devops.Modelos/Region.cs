using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.modelos
{
    public class Region
    {
        [Key]
        public Guid Id_region { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Id_pais")]
        public Guid id_pais { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual ICollection<Comuna> Comunas { get; set; }
        public virtual Pais pais { get; set; }
    }
}
