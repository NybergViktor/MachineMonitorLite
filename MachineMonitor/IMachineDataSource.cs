public interface IMachineDataSource
{
    Task<List<MachineData>> GetMachineDataAsync();
}