using System;
using System.Collections.Generic;
using System.Linq;

public class MachineService : IMachineService
{
    public void PrintMachines(List<MachineData> machines)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to print machines: {ex.Message}");
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
        var avg = GetAverageTemperature(machines);
        Console.WriteLine($"Average temperature (running machines): {avg}");
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

    public double GetAverageTemperature(List<MachineData> machines)
    {
        var runningMachines = machines
            .Where(m => m.IsRunning)
            .ToList();

        if (runningMachines.Count == 0)
            return 0;

        return runningMachines.Average(m => m.Temperature);
    }
}