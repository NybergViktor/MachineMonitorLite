namespace MachineMonitor.Tests;

using Xunit;

public class MachineServiceTests
{
    [Fact]
    public void GetAverageTemperature_ShouldReturnCorrectAverage()
    {
        // Arrange
        var service = new MachineService();

        var machines = new List<MachineData>
        {
            new MachineData { Temperature = 80, IsRunning = true },
            new MachineData { Temperature = 100, IsRunning = true },
            new MachineData { Temperature = 50, IsRunning = false }
        };

        // Act
        var result = service.GetAverageTemperature(machines);

        // Assert
        Assert.Equal(90, result);
    }

    [Fact]
    public void GetAverageTemperature_ShouldReturnZero_WhenNoRunningMachines()
    {
        // Arrange
        var service = new MachineService();

        var machines = new List<MachineData>
        {
            new MachineData { Temperature = 80, IsRunning = false },
            new MachineData { Temperature = 100, IsRunning = false }
        };

        // Act
        var result = service.GetAverageTemperature(machines);

        // Assert
        Assert.Equal(0, result);
    }
}