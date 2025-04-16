using com.devops.Aplicacion.Paises.Commdand;
using com.devops.Aplicacion.Paises.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.devops.API.Controllers
{
    [ApiController]
    [Route("Pais")]
    public class PaisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paises = await _mediator.Send(new GetAllPaisesQuery());
            return Ok(paises);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPais(Guid id)
        {
            var pais = await _mediator.Send(new GetPaisIDQuery { Id_Pais = id });
            if (pais.Id_pais == Guid.Empty )
            {
                return NotFound();
            }
            return Ok(pais);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePaisCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Pais creado correctamente" });
        }
    }
}
