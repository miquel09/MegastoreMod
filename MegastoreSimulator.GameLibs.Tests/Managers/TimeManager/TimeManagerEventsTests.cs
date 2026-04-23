using AwesomeAssertions;
using MegastoreSimulator.GameLibs.Managers.TimeManager;

namespace MegastoreSimulator.GameLibs.Tests.Managers.TimeManager;

[TestClass]
public class TimeManagerEventsTests
{
    [TestMethod]
    public void FireOnDayEnd_ShouldFireCorrectly_WhenHappyFlow()
    {
        // Arrange
        var wasCalled = false;
        TimeManagerEvents.OnDayEnd += () =>
        {
            wasCalled = true;
        };

        // Act
        TimeManagerEvents.FireOnDayEnd();

        // Assert
        wasCalled.Should().BeTrue();
    }

    [TestMethod]
    public void FireOnDayStart_ShouldFireCorrectly_WhenHappyFlow()
    {
        // Arrange
        var wasCalled = false;
        TimeManagerEvents.OnDayStart += () =>
        {
            wasCalled = true;
        };

        // Act
        TimeManagerEvents.FireOnDayStart();

        // Assert
        wasCalled.Should().BeTrue();
    }
}
