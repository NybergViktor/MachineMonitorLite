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
                Console.WriteLine($"Pressure: {machine.Pressure}");
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

    public List<MachineData> GetRunningMachines(List<MachineData> machines)
    {
        if (machines.Count == 0)
            return new List<MachineData>();

        return machines.Where(m => m.IsRunning.Equals(true)).ToList();
    }

    /// <summary>
    /// Print running machines using Console.WriteLine
    /// </summary>
    /// <param name="machines"></param>
    public void PrintRunningMachines(List<MachineData> machines)
    {
        var runningMachines = GetRunningMachines(machines);

        foreach (var machine in runningMachines)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Machine: {machine.MachineName}");
            Console.WriteLine($"Timestamp: {machine.Timestamp}");
            Console.WriteLine("----------------------");
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

    public void PrintHighPressureMachines(List<MachineData> machines)
    {
        var highPressureMachines = machines.Where(m => m.Pressure > 100).ToList();

        foreach (var machine in highPressureMachines)
        {
            Console.WriteLine($"Machine {machine.MachineName} has high pressure: {machine.Pressure}");
        }
    }

    /// <summary>
    /// Gets running machines and return any with temperature above 110
    /// </summary>
    /// <requires>List of machines</requires>
    /// <param name="machines"></param>
    /// <returns></returns>
    public bool GetMachinesThatHasCriticalAlarm(List<MachineData> machines)
    {
        var runnningMachines = GetRunningMachines(machines);

        return runnningMachines.Any(m => m.Temperature > 110);
    }

    /// <summary>
    /// Return machines that exceeds a critcal level of pressure above 120 or temperature above 110.
    /// </summary>
    /// <param name="machines"></param>
    /// <returns></returns>
    public List<MachineData> GetMachinesWithCriticalPressure(List<MachineData> machines)
    {
        if (machines.Count == 0)
            return new List<MachineData>();

        return machines.Where(m => m.Pressure > 120 || m.Temperature > 110).ToList();
    }

}