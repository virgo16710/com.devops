using com.devops.Aplicacion.Paises.Commdand;
using com.devops.Aplicacion.Paises.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.devops.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var paises = await _mediator.Send(new GetAllPaisesQuery());
            return Ok(paises);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreatePaisCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Pais creado correctamente" });
        }
    }
}
