namespace com.devops.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Controladores.PaisControllerTest paisControllerTest = new Controladores.PaisControllerTest();
    }
    [Fact]
    public void PruebaBasica()
    {
        Assert.Equal(1, 1);
    }
}
