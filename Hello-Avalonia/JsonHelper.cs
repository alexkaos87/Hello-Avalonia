using System.IO;
using System.Text.Json;

namespace HelloAvalonia
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        public static string ToJson<T>(in T obj) where T : class =>
            JsonSerializer.Serialize(obj, _jsonOptions);

        public static void ToFile<T>(in string filePath, in T obj) where T : class
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, ToJson(obj));
        }

        public static T? FromJson<T>(string content) where T : class
            => JsonSerializer.Deserialize<T>(content);

        public static T? FromFile<T>(string filePath) where T : class
            => !File.Exists(filePath) ? default : FromJson<T>(File.ReadAllText(filePath));
    }
}
