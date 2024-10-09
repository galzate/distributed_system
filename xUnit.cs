using Moq;
using Xunit;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Threading.Tasks;


public class CacheControllerTests
{
    private readonly Mock<IDistributedCache> _cacheMock;
    private readonly CacheController _controller;


    public CacheControllerTests()
    {
        _cacheMock = new Mock<IDistributedCache>();
        _controller = new CacheController(_cacheMock.Object);
    }


    [Fact]
    public async Task Get_ReturnsValue_WhenKeyExists()
    {
        // Arrange
        var key = "testKey";
        var value = "testValue";
        _cacheMock.Setup(c => c.GetStringAsync(key)).ReturnsAsync(value);


        // Act
        var result = await _controller.Get(key);


        // Assert
        Assert.IsType<OkObjectResult>(result);
    }


    // Más pruebas aquí...
}
