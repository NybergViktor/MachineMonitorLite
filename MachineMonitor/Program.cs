using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

var services = new ServiceCollection();

// Register
services.AddSingleton<MachineAnalyzer>();
services.AddSingleton<IMachineService, MachineService>();
services.AddSingleton<IMachineDataSource, PlcMachineDataSource>();
services.AddSingleton<MachineDataRetryHelper>();

var serviceProvider = services.BuildServiceProvider();

// Resolve
var machineService = serviceProvider.GetRequiredService<IMachineService>();
var provider = serviceProvider.GetRequiredService<IMachineDataSource>();
var retryHelper = serviceProvider.GetRequiredService<MachineDataRetryHelper>();

while (true)
{
    try
    {
        var machineDataList = await retryHelper.GetMachineDataWithRetryAsync(provider);

        Console.Clear();

        machineService.PrintMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintRunningMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintHighPressureMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintAverageTemperature(machineDataList);
        Console.WriteLine();

        machineService.PrintSystemStatus(machineDataList);
        Console.WriteLine();

        machineService.PrintMostCriticalMachine(machineDataList);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[CRITICAL ERROR]: {ex.Message}");
    }

    await Task.Delay(2000);
}