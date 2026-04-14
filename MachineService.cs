using System;
using System.Collections.Generic;
using System.Linq;

public class MachineService : IMachineService
{
    public void PrintMachines(List<MachineData> machines)
    {
        foreach (var machine in machines)
        {
            Console.WriteLine($"Machine: {machine.MachineName}");
            Console.WriteLine($"Temperature: {machine.Temperature}");
            Console.WriteLine($"Running: {machine.IsRunning}");
            Console.WriteLine($"Timestamp: {machine.Timestamp}");
            Console.WriteLine("----------------------------");
        }
    }

    public void PrintRunningMachines(List<MachineData> machines)
    {
        foreach (var machine in machines)
        {
            if (machine.IsRunning)
            {
                Console.WriteLine($"{machine.MachineName} is running.");
            }
        }
    }

    public void PrintHotMachines(List<MachineData> machines)
    {
        var hotmachines = machines.Where(m => m.Temperature > 90).ToList();

        Console.WriteLine("Hot Machines:");

        foreach (var machine in hotmachines)
        {
            Console.WriteLine($"{machine.MachineName} - {machine.Temperature}");
        }
    }

    public void PrintAverageTemperature(List<MachineData> machines)
    {
        var runningmachines = machines.Where(m => m.IsRunning).ToList();

        if (runningmachines.Count() == 0)
        {
            Console.WriteLine("No running machines to calculate average temperature.");
            return;
        }

        var averageTemp = runningmachines.Average(m => m.Temperature);

        Console.WriteLine($"Average temperature (running machines): {averageTemp}");
    }

    public void PrintStoppedMachines(List<MachineData> machines)
    {
        foreach (var machine in machines)
        {
            if (!machine.IsRunning)
            {
                Console.WriteLine($"{machine.MachineName} is stopped.");
            }
        }
    }
}