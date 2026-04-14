await MainAsync();

// Simulate plc data
static async Task MainAsync()
{
    var machineService = new MachineService();
    var provider = new MachineDataProvider();

    while (true)
    {
        var machineDataList = provider.GetMachineData();

        Console.Clear();

        machineService.PrintMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintHotMachines(machineDataList);
        Console.WriteLine();

        machineService.PrintAverageTemperature(machineDataList);

        await Task.Delay(1000);
    }
}