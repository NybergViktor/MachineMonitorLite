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


    /// <summary>
    /// Returns the most critical machine from the specified list based on temperature and pressure thresholds.
    /// </summary>
    /// <remarks>A machine is considered critical if its temperature is greater than 110 or its pressure is
    /// greater than 120. If multiple machines meet the criteria, the one with the highest temperature is selected; if
    /// temperatures are equal, the one with the higher pressure is chosen.</remarks>
    /// <param name="machines">The list of machines to evaluate. Cannot be null.</param>
    /// <returns>A MachineData instance representing the machine with the highest temperature (and, if tied, the highest
    /// pressure) that exceeds a temperature of 110 or a pressure of 120; otherwise, null if no machines meet the
    /// criteria.</returns>
    public MachineData? GetMostCriticalMachine(List<MachineData> machines)
    {
        return machines.Where(m => m.Temperature > 110 || m.Pressure > 120).OrderByDescending(m => m.Temperature).ThenByDescending(m => m.Pressure).FirstOrDefault();
    }

    /// <summary>
    /// Attempts to retrieve machine data from the specified data source, retrying the operation up to a specified
    /// number of times if an error occurs.
    /// </summary>
    /// <remarks>If an exception occurs while retrieving machine data, the method waits briefly before
    /// retrying. The method throws an exception only if all retry attempts fail.</remarks>
    /// <param name="dataSource">The data source from which to retrieve machine data. Cannot be null.</param>
    /// <param name="maxRetries">The maximum number of retry attempts to perform if retrieving machine data fails. Must be greater than zero. The
    /// default is 3.</param>
    /// <returns>A list of machine data retrieved from the data source.</returns>
    /// <exception cref="Exception">Thrown if the operation fails after the specified number of retry attempts.</exception>
    public async Task<List<MachineData>> GetMachineDataWithRetryAsync(IMachineDataSource dataSource, int maxRetries = 3)
    {
        for (int i = 1; i <= maxRetries; i++)
        {
        try
        {
            return await dataSource.GetMachineDataAsync();
        }
        catch (Exception ex)
        {
            if (i == maxRetries)
            {
                throw new Exception($"Could not get machine data after {maxRetries} attempts.", ex);
            }
            await Task.Delay(200);
        }
        throw new Exception("Unexpected error in retry logic when trying to get machine data.");
    }
}