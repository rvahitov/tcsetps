using Serilog;

namespace Correct.Storage.RestApi
{
    public static class LogConfig
    {
        public static void Configure()
        {
            var config = new LoggerConfiguration()
                .ReadFrom.AppSettings();
            Log.Logger = config.CreateLogger();
        }
    }
}