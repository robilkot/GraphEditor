using System.Text.Json;
using System.Text.Json.Serialization;

namespace LW5.FileSystem
{
    public static class FileSystem
    {
        private static readonly JsonSerializerOptions s_options = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true,
            Converters = {
                new ColorJsonConverter(),
                new PointJsonConverter()
            }
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

    public class ColorJsonConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => ColorTranslator.FromHtml(reader.GetString());
        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStringValue("#"
                + value.R.ToString("X2")
                + value.G.ToString("X2")
                + value.B.ToString("X2")
                .ToLower());
        }
    }

    public class PointJsonConverter : JsonConverter<Point>
    {
        public override Point Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string[] coordinates = reader.GetString().Split(';');
            return new(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }
        public override void Write(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.X.ToString() + ';' + value.Y.ToString());
        }
    }
}
