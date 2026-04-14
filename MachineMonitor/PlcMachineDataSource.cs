public class PlcMachineDataSource : IMachineDataSource
{
    private readonly Random _random = new Random();

    public List<MachineData> GetMachineData()
    {
        Thread.Sleep(200); // Simulate PLC communication delay

        // Simulate occasional communication failure
        if (_random.Next(0, 10) == 1)
        {
            throw new Exception("Simulated PLC communication failure");
        }

        return new List<MachineData>
        {
            new MachineData
            {
                MachineName = "PLC-Mixer",
                Temperature = _random.Next(60, 120),
                IsRunning = true,
                Timestamp = DateTime.Now
            },
            new MachineData
            {
                MachineName = "PLC-Press",
                Temperature = _random.Next(70, 130),
                IsRunning = _random.Next(0, 2) == 1,
                Timestamp = DateTime.Now
            }
        };
    }
}