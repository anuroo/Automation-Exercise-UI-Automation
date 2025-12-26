using Newtonsoft.Json;
namespace AutomationFramework.Utilities
{
    public class JsonReader
    {
        public static T ReadFile<T>(string filePath)
        {
            string json=File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}