using com.devops.modelos;
using com.devops.persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.devops.Aplicacion.Paises.Queries
{
    public class GetPaisIDHandler : IRequestHandler<GetPaisIDQuery, Pais>
    {
        private readonly ApplicationDBContext _db;
        public GetPaisIDHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<Pais> Handle(GetPaisIDQuery request, CancellationToken cancellationToken)
        {
            return await _db.Pais.FirstOrDefaultAsync(p => p.Id_pais == request.Id_Pais, cancellationToken);
        }
    }
}
