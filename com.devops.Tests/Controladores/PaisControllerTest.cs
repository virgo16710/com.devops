using com.devops.Aplicacion.Paises.Commdand;
using com.devops.Aplicacion.Paises.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text.Json;

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
        [Fact]
        public async Task Post_ReturnsOkResult_WhenPaisIsCreated()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send<Unit>((IRequest<Unit>)It.IsAny<CreatePaisCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value); // porque tu handler no devuelve nada

            var controller = new com.devops.API.Controllers.PaisController(mockMediator.Object);

            var command = new CreatePaisCommand
            {
                Nombre = "Ecuador"
            };

            // Act
            var result = await controller.Post(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Convertir el resultado a JSON, luego a diccionario
            var json = JsonSerializer.Serialize(okResult.Value);
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            Assert.Equal("Pais creado correctamente", dict["message"]);


            mockMediator.Verify(m => m.Send(It.IsAny<CreatePaisCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
