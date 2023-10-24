using System.Text.Json;
using System.Text.Json.Serialization;

namespace LW5.FileSystem
{
    public static class FileSystem
    {
        private static JsonSerializerOptions s_options = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };
        public static void SaveToFile(GraphRecord graphRecord, string filePath)
        {
            File.WriteAllText(filePath, string.Empty);

            using (FileStream fileStream = File.OpenWrite(filePath))
            {
                JsonSerializer.Serialize(fileStream, graphRecord, s_options);
            }
        }
        public static GraphRecord ReadFromFile(string filePath)
        {
            GraphRecord? toRead;

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                toRead = JsonSerializer.Deserialize<GraphRecord>(fileStream, s_options);
            }

            if (toRead == null) throw new Exception("Error reading file");
            return toRead;
        }
    }
}
