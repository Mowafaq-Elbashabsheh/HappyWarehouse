using HappyWarehouse.App.Helpers;
using HappyWarehouse.App.Models.Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using System.Diagnostics;
using System.Text.Json;

namespace HappyWarehouse.API.Middleware
{
    public class CustomFileSink : ILogEventSink
    {
        public CustomFileSink()
        {
        }

        public async void Emit(LogEvent logEvent)
        {
            var filePath = Helper.GetLogFilePath();

            var directoryPath = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                using (var fileStream = File.Create(filePath))
                {
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine("Log created on " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                    }
                }
            }

            try
            {
                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    if (logEvent.Exception != null && logEvent.TraceId != null)
                    {
                        await streamWriter.WriteLineAsync(GetJsonLog(logEvent));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.Write("An IO Error Occurred");
            }
        }

        public string GetJsonLog(LogEvent logEvent)
        {
            var logs = new LogsFormat();
            
            if(logEvent.TraceId != null)
            {
                logs.TraceId = logEvent.TraceId.Value.ToString();
            }
            else
            {
                logs.TraceId = "";
            }
            logs.Time = logEvent.Timestamp.DateTime;
            logs.Message = logEvent.Exception?.Message;
            logs.InnerException = logEvent.Exception?.InnerException?.ToString();

            return JsonSerializer.Serialize(logs);
        }
    }
}
