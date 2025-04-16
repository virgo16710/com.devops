using com.devops.Aplicacion.Paises.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace com.devops.Tests.Controladores
{
    public class PaisControllerTest
    {
        [Fact]
        public async Task GetAll_ReturnsOKResult_WithListOfPaises()
        {
            var mockMediator = new Mock<IMediator>();
                mockMediator
                .Setup(m=>m.Send(It.IsAny<GetAllPaisesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<modelos.Pais>
                {
                    new modelos.Pais { Id_pais = Guid.NewGuid(), Nombre = "Pais1" },
                    new modelos.Pais { Id_pais = Guid.NewGuid(), Nombre = "Pais2" }
                });
            var controller = new com.devops.API.Controllers.PaisController(mockMediator.Object);
            var result = await controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var paises = Assert.IsAssignableFrom<List<modelos.Pais>>(okResult.Value);
            Assert.Equal(2, paises.Count);
        }
        [Fact]
        public async Task GetIdPaisResult_WhenNoPaises()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send(It.IsAny<GetPaisIDQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new modelos.Pais());
            var controller = new com.devops.API.Controllers.PaisController(mockMediator.Object);
            var result = await controller.GetPais(Guid.Empty);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
