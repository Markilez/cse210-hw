using System;
using System.IO;

public class ActivityLogger
{
    private string logFilePath = "activity_log.txt";

    public void LogActivity(string activityName, int duration)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {activityName} for {duration} seconds.");
        }
    }
}
