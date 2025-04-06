using Microsoft.Extensions.Configuration;

namespace Core.Utils
{
    public static class ConfigHelper
    {
        private static IConfiguration? _config;

        public static IConfiguration Config =>
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        public static string BrowserType => Config["BrowserType"] ?? "edge";

        public static bool Headless => bool.TryParse(Config["Headless"], out var result) && result;
    }
}
