using Newtonsoft.Json.Linq;

namespace AutomationFramework.Config
{
    public class Configreader
    {
        private static JObject _config;
         static Configreader()
        {
            string configPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Config",
                "appsettings.json"
            );
            _config=JObject.Parse(File.ReadAllText(configPath));
        }
        public static string GetBrowser()
        {
            return _config["browser"]?.ToString();
        }
        public static string GetBaseUrl()
        {
            return _config["baseUrl"]?.ToString();
        }
        public static bool IsHeadless()
        {
            return _config["headless"]?.ToObject<bool>()?? false;
        }
    }
}