using com.devops.modelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.Aplicacion.Paises.Queries
{
    public class GetPaisIDQuery : IRequest<Pais>
    {
        public Guid Id_Pais { get; set; }
    }
}
