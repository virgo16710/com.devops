using com.devops.modelos;
using com.devops.persistencia;
using MediatR;

namespace com.devops.Aplicacion.Paises.Commdand
{
    public class CreatePaisHandler : IRequestHandler<CreatePaisCommand>
    {
        private readonly ApplicationDBContext _db;
        public CreatePaisHandler(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
        {
            var pais = new Pais
            {
                Id_pais = Guid.NewGuid(),
                Nombre = request.Nombre,
                FechaCreacion = DateTime.Now
            };
            await _db.Pais.AddAsync(pais,cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<CreatePaisCommand>.Handle(CreatePaisCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
