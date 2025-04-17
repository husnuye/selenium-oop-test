using System.IO;
using System.Text.Json;

namespace SeleniumOOPTest.Utils
{
    public class ConfigReader
    {
        private static readonly string configPath = "appsettings.json";
        private static readonly JsonDocument config = JsonDocument.Parse(File.ReadAllText(configPath));

        public static string GetSetting(string key)
        {
            if (!config.RootElement.TryGetProperty(key, out var value))
            {
                throw new KeyNotFoundException($"Key '{key}' not found in appsettings.json. Check casing or typos.");
            }

            return value.GetString();
        }
    }
}