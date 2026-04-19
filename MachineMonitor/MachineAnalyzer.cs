using System.Collections.Generic;
using System.Linq;

public class MachineAnalyzer
{
    public MachineData? GetMostCriticalMachine(List<MachineData> machines)
    {
        return machines
            .Where(m => m.Temperature > 110 || m.Pressure > 120)
            .OrderByDescending(m => m.Temperature)
            .ThenByDescending(m => m.Pressure)
            .FirstOrDefault();
    }

    public bool HasAnyCriticalMachine(List<MachineData> machines)
    {
        return machines.Any(m => m.Temperature > 110 || m.Pressure > 120);
    }

    public List<MachineData> GetCriticalMachines(List<MachineData> machines)
    {
        return machines
            .Where(m => m.Temperature > 110 || m.Pressure > 120)
            .ToList();
    }

    public List<MachineData> GetRunningMachines(List<MachineData> machines)
    {
        return machines
            .Where(m => m.IsRunning)
            .ToList();
    }

    public List<MachineData> GetStoppedMachines(List<MachineData> machines)
    {
        return machines
            .Where(m => !m.IsRunning)
            .ToList();
    }

    public List<MachineData> GetHotMachines(List<MachineData> machines, double threshold = 90)
    {
        return machines
            .Where(m => m.Temperature > threshold)
            .ToList();
    }

    public List<MachineData> GetHighPressureMachines(List<MachineData> machines, int threshold = 100)
    {
        return machines
            .Where(m => m.Pressure > threshold)
            .ToList();
    }

    public double GetAverageTemperature(List<MachineData> machines)
    {
        var runningMachines = GetRunningMachines(machines);

        if (!runningMachines.Any())
        {
            return 0;
        }

        return runningMachines.Average(m => m.Temperature);
    }

    public string GetSystemStatus(List<MachineData> machines)
    {
        if (HasAnyCriticalMachine(machines))
        {
            return "CRITICAL";
        }

        if (machines.Any(m => !m.IsRunning))
        {
            return "WARNING";
        }

        return "OK";
    }
}