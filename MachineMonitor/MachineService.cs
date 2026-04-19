using System;
using System.Collections.Generic;

public class MachineService : IMachineService
{
    private readonly MachineAnalyzer _analyzer;

    public MachineService(MachineAnalyzer analyzer)
    {
        _analyzer = analyzer;
    }

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

    public void PrintRunningMachines(List<MachineData> machines)
    {
        var runningMachines = _analyzer.GetRunningMachines(machines);

        foreach (var machine in runningMachines)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Machine: {machine.MachineName}");
            Console.WriteLine($"Timestamp: {machine.Timestamp}");
            Console.WriteLine("----------------------");
        }
    }

    public void PrintStoppedMachines(List<MachineData> machines)
    {
        var stoppedMachines = _analyzer.GetStoppedMachines(machines);

        foreach (var machine in stoppedMachines)
        {
            Console.WriteLine($"{machine.MachineName} is stopped.");
        }
    }

    public void PrintHotMachines(List<MachineData> machines)
    {
        var hotMachines = _analyzer.GetHotMachines(machines);

        Console.WriteLine("Hot machines:");

        foreach (var machine in hotMachines)
        {
            Console.WriteLine($"{machine.MachineName} - {machine.Temperature}");
        }
    }

    public void PrintHighPressureMachines(List<MachineData> machines)
    {
        var highPressureMachines = _analyzer.GetHighPressureMachines(machines);

        Console.WriteLine("High pressure machines:");

        foreach (var machine in highPressureMachines)
        {
            Console.WriteLine($"{machine.MachineName} - {machine.Pressure}");
        }
    }

    public void PrintAverageTemperature(List<MachineData> machines)
    {
        var averageTemperature = _analyzer.GetAverageTemperature(machines);
        Console.WriteLine($"Average temperature (running machines): {averageTemperature}");
    }

    public void PrintSystemStatus(List<MachineData> machines)
    {
        var status = _analyzer.GetSystemStatus(machines);
        Console.WriteLine($"System status: {status}");
    }

    public void PrintMostCriticalMachine(List<MachineData> machines)
    {
        var criticalMachine = _analyzer.GetMostCriticalMachine(machines);

        if (criticalMachine == null)
        {
            Console.WriteLine("No critical machines found.");
            return;
        }

        Console.WriteLine("Most critical machine:");
        Console.WriteLine($"Machine: {criticalMachine.MachineName}");
        Console.WriteLine($"Temperature: {criticalMachine.Temperature}");
        Console.WriteLine($"Pressure: {criticalMachine.Pressure}");
        Console.WriteLine($"Running: {criticalMachine.IsRunning}");
        Console.WriteLine($"Timestamp: {criticalMachine.Timestamp}");
    }
}