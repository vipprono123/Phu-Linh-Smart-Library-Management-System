using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Common
{
  [ExcludeFromCodeCoverage]
  public class DateTimeConverter : JsonConverter<DateTime>
  {
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      return DateTime.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
      string jsonDateTimeFormat = DateTime.SpecifyKind(value, DateTimeKind.Utc)
                                          .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);

      writer.WriteStringValue(jsonDateTimeFormat);
    }
  }
}