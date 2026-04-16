using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

var services = new ServiceCollection();


// Register
services.AddSingleton<IMachineService, MachineService>();
services.AddSingleton<IMachineDataSource, PlcMachineDataSource>();

var serviceProvider = services.BuildServiceProvider();

// Resolve
var machineService = serviceProvider.GetRequiredService<IMachineService>();
var provider = serviceProvider.GetRequiredService<IMachineDataSource>();

// Simulate data
while (true)
{
    try
    {
        var machineDataList = await provider.GetMachineDataAsync();

        Console.Clear();

        // machineService.PrintMachines(machineDataList);
        // Console.WriteLine();
        // machineService.PrintHotMachines(machineDataList);
        // Console.WriteLine();
        // machineService.PrintHighPressureMachines(machineDataList);
        // Console.WriteLine();
        machineService.PrintRunningMachines(machineDataList);
        Console.WriteLine();
        machineService.GetMachinesWithCriticalPressure(machineDataList);
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[CRITICAL ERROR]: {ex.Message}");
    }

    await Task.Delay(2000);
}