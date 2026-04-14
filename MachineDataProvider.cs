public class MachineDataProvider
{
    private readonly Random _random = new Random();

    public List<MachineData> GetMachineData()
    {
        return new List<MachineData>
        {
            new MachineData
            {
                MachineName = "Mixer-01",
                Temperature = _random.Next(60, 120),
                IsRunning = true,
                Timestamp = DateTime.Now
            },
            new MachineData
            {
                MachineName = "Press-02",
                Temperature = _random.Next(70, 120),
                IsRunning = _random.Next(0, 2) == 1,
                Timestamp = DateTime.Now
            },
            new MachineData
            {
                MachineName = "Conveyor-03",
                Temperature = _random.Next(0, 120),
                IsRunning = false,
                Timestamp = DateTime.Now
            }
        };
    }
}