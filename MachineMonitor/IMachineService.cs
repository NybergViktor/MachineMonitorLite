public interface IMachineService
{
    void PrintMachines(List<MachineData> machines);
    void PrintRunningMachines(List<MachineData> machines);
    void PrintStoppedMachines(List<MachineData> machines);
    void PrintHotMachines(List<MachineData> machines);
    void PrintHighPressureMachines(List<MachineData> machines);
    void PrintAverageTemperature(List<MachineData> machines);
    void PrintSystemStatus(List<MachineData> machines);
    void PrintMostCriticalMachine(List<MachineData> machines);
}