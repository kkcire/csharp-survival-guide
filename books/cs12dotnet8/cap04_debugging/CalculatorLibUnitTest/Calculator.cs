using CalculatorLib; // To use Calculator.
namespace CalculatorLibUnitTests;

public class CalculatorUnitTests
{
    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(3, 7, 10)]
    [InlineData(20, 30, 50)]

    public void TestAdding(double a, double b, double expected)
    {
        //Arrange
        Calculator calc = new();
        // Act
        double actual = calc.Add(a, b);
        // Assert
        Assert.Equal(expected, actual);
    }
}