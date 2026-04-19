using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MachineDataRetryHelper
{
    public async Task<List<MachineData>> GetMachineDataWithRetryAsync(
        IMachineDataSource dataSource,
        int maxRetries = 3)
    {
        if (dataSource == null)
        {
            throw new ArgumentNullException(nameof(dataSource));
        }

        if (maxRetries <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxRetries), "maxRetries must be greater than 0.");
        }

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                return await dataSource.GetMachineDataAsync();
            }
            catch (Exception ex)
            {
                if (attempt == maxRetries)
                {
                    throw new Exception($"Could not get machine data after {maxRetries} attempts.", ex);
                }

                await Task.Delay(200);
            }
        }

        throw new Exception("Unexpected error in retry logic.");
    }
}