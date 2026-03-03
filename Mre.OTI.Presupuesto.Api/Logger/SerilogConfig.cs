using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
//using Serilog.Sinks.Elasticsearch;
using System;

namespace Mre.tecnologia.util.lib.Logger
{
    public class SerilogConfig
    {
        public static void ConfigureLog(string nameApplication)
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            var logConfig = configuration.GetSection("LogConfig");
            if (!logConfig.Exists())
                throw new Exception("No se encuentra en el appSettings 'LogConfig'.");

            string logType = configuration["LogConfig:LogType"];
            if (string.IsNullOrEmpty(logType))
                throw new Exception("No se encuentra en el appSettings 'LogConfig:LogType'.");

            var logEventLevel = logConfig.GetValue<int>("LogEventLevel");
            var logEventLevelEnum = (LogEventLevel)logEventLevel;

            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft.AspNetCore", logEventLevelEnum)
                .WriteTo.Console();

            if (logType.Contains("File"))
                ConfigureLogFile(nameApplication, configuration, loggerConfiguration);

            //if (logType.Contains("Elasticsearch"))
            // ConfigureLogElasticSearch(nameApplication, configuration, loggerConfiguration);

            Log.Logger = loggerConfiguration.CreateLogger();
        }

        private static void ConfigureLogFile(string nameApplication, IConfiguration configuration, LoggerConfiguration loggerConfiguration)
        {
            var logConfig = configuration.GetSection("LogConfig");
            var logPath = logConfig.GetValue<string>("LogPath");
            if (string.IsNullOrEmpty(logPath))
                throw new Exception("No se encuentra en el appSettings 'LogConfig:LogPath'.");

            var logEventLevel = logConfig.GetValue<int>("LogEventLevel");
            var logEventLevelEnum = (LogEventLevel)logEventLevel;

            var fileSizeLimitBytes = logConfig.GetValue<int>("FileSizeLimitBytes");
            if (fileSizeLimitBytes < 1)
                throw new Exception("No se encuentra en el appSettings 'LogConfig:FileSizeLimitBytes'.");

            var rollOnFileSizeLimit = logConfig.GetValue<bool>("RollOnFileSizeLimit");
            var retainedFileCountLimit = logConfig.GetValue<int>("RetainedFileCountLimit");
            if (retainedFileCountLimit < 1)
                throw new Exception("No se encuentra en el appSettings 'LogConfig:RetainedFileCountLimit'.");

            logPath = $"{logPath}\\{nameApplication}\\{nameApplication}-{DateTime.UtcNow:yyyy-MM-dd}.txt";

            loggerConfiguration.WriteTo.File(
                 path: logPath,
                 restrictedToMinimumLevel: logEventLevelEnum,
                 fileSizeLimitBytes: fileSizeLimitBytes,
                 rollOnFileSizeLimit: rollOnFileSizeLimit,
                 retainedFileCountLimit: retainedFileCountLimit);

        }


    }
}
