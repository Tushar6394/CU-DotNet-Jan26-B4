using Xunit;
using NorthwindCatalog.Services.DTOs;

public class ProductTests
{
    [Fact]
    public void InventoryValue_ShouldCalculateCorrectly()
    {
        // Arrange
        var product = new ProductDto
        {
            UnitPrice = 10,
            UnitsInStock = 5
        };

        // Act
        var result = product.InventoryValue;

        // Assert
        Assert.Equal(50, result);
    }
}