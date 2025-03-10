using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BattleTanks.Core.Storage
{
    public class JsonSettingsStore
    {
        public async Task<T> Load<T>(string name)
        {
            var appDir = PathConfigurations.GetAppDirectory();
            var filePath = Path.Combine(appDir, name);
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            var content = await File.ReadAllTextAsync(filePath);

            var result = JsonSerializer.Deserialize<T>(content, GetSerializerOptions());

            return result;
        }

        public async Task SaveAsync(string fileName, object data)
        {
            var appDir = PathConfigurations.GetAppDirectory();
            var filePath = Path.Combine(appDir, fileName);

            var content = JsonSerializer.Serialize(data, GetSerializerOptions());
            await File.WriteAllTextAsync(filePath, content);
        }

        private static JsonSerializerOptions GetSerializerOptions()
        {
            var opt = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            opt.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            return opt;
        }
    }
}
