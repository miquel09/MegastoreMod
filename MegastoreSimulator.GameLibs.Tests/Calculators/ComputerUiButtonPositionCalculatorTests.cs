//using AwesomeAssertions;
//using MegastoreSimulator.GameLibs.Calculators;
//using System.Numerics;

//namespace MegastoreSimulator.GameLibs.Tests.Calculators;

//[TestClass]
//public class ComputerUiButtonPositionCalculatorTests
//{
//    [TestMethod]
//    [DataRow(0, -0.5359f, 0.2787f, 0)]
//    [DataRow(1, -0.5359f, 0.1187f, 0)]
//    [DataRow(3, -0.5359f, -0.2013f, 0)]
//    [DataRow(4, -0.3559f, 0.2787f, 0)]
//    public void CalculateButtonPosition_ShouldReturnCorrectPosition_WhenIndexIsWithinRange(int index, float x, float y, float z)
//    {
//        // Arrange
//        var expectedVector = new Vector3(x, y, z);

//        // Act
//        var result = ComputerUiButtonPositionCalculator.CalculateButtonPosition(index);

//        // Assert
//        result.X.Should().Be(expectedVector.X);
//        result.Y.Should().Be(expectedVector.Y);
//        result.Z.Should().Be(expectedVector.Z);
//    }
//}
