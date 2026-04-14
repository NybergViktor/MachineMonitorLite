using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();


// Register
services.AddSingleton<IMachineService, MachineService>();
services.AddSingleton<MachineDataProvider>();

var serviceProvider = services.BuildServiceProvider();

// Resolve
var machineService = serviceProvider.GetRequiredService<IMachineService>();
var provider = serviceProvider.GetRequiredService<MachineDataProvider>();

// Simulate plc data
while (true)
{
    try
    {
        var machineDataList = provider.GetMachineData();

        Console.Clear();

        machineService.PrintMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintHotMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintAverageTemperature(machineDataList);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[CRITICAL ERROR]: {ex.Message}");
    }

    await Task.Delay(2000);
}