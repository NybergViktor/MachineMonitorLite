public interface IMachineService
{
    void PrintMachines(List<MachineData> machines);
    void PrintRunningMachines(List<MachineData> machines);
    void PrintHotMachines(List<MachineData> machines);
    void PrintAverageTemperature(List<MachineData> machines);
    void PrintStoppedMachines(List<MachineData> machines);
    void PrintHighPressureMachines(List<MachineData> machines);
    List<MachineData> GetRunningMachines(List<MachineData> machines);
    List<MachineData> GetMachinesWithCriticalPressure(List<MachineData> machines);
    bool GetMachinesThatHasCriticalAlarm(List<MachineData> machines);
    MachineData GetMostCriticalMachine(List<MachineData> machines);
    Task<List<MachineData>> GetMachineDataWithRetryAsync(IMachineDataSource dataSource, int maxRetries)
}