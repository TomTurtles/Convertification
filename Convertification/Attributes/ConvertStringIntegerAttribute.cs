using System;
using System.Collections.Generic;
namespace Convertification.Attributes;

public class ConvertStringIntegerAttribute : JsonConverterAttribute
{
    public ConvertStringIntegerAttribute(): base(typeof(StringIntegerConverter))
    {
        
    }
}

public class StringIntegerConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString()!.ToInteger(),
                JsonTokenType.Number => reader.GetInt32(),
                _ => throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}"),
            };
        }
        catch (Exception ex)
        {
            throw new JsonException("", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        // Schreib den int-Wert als String in JSON
        writer.WriteStringValue(value.ToString(Convertification.CultureInfo));
    }
}