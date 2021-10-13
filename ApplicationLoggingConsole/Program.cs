using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace ApplicationLoggingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using ILoggerFactory loggerFactory =
                LoggerFactory.Create(builder =>
                    builder
                    .AddFilter("ApplicationLoggingConsole.Program", LogLevel.Warning)
                    .AddConsole(options => 
                    {
                        options.IncludeScopes = true;
                        options.TimestampFormat = "dd-MM-yyyy hh:mm:ss ";
                    }));

            ILogger logger = loggerFactory.CreateLogger<Program>();

            logger.LogTrace("Log information message.");
            logger.LogDebug("Log information message.");
            logger.LogInformation("Log information message.");
            logger.LogWarning("Log warning message.");
            logger.LogError("Log error message.");
            logger.LogCritical("Log critical message.");
        }
    }

     public class OptionsMonitor<T> : IOptionsMonitor<T>
    {
        private readonly T options;

        public OptionsMonitor(T options)
        {
            this.options = options;
        }

        public T CurrentValue => options;

        public T Get(string name) => options;

        public IDisposable OnChange(Action<T, string> listener) => new NullDisposable();

        private class NullDisposable : IDisposable
        {
            public void Dispose() { }
        }
    }
}
