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
    public class GetAllPaisesHandler : IRequestHandler<GetAllPaisesQuery, List<Pais>>
    {
        private readonly ApplicationDBContext _db;
        public GetAllPaisesHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<List<Pais>> Handle(GetAllPaisesQuery request, CancellationToken cancellationToken)
        {
            return await _db.Pais.Include(p => p.Regiones).ToListAsync(cancellationToken);
        }
    }
}
