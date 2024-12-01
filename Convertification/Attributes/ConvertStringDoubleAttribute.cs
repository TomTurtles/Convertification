namespace Convertification.Attributes;

public class ConvertStringDoubleAttribute : JsonConverterAttribute
{
    public ConvertStringDoubleAttribute(): base(typeof(StringDoubleConverter))
    {
        
    }
}

public class StringDoubleConverter : JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString()!.ToDouble(),
                JsonTokenType.Number => reader.GetDouble(),
                _ => throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}"),
            };
        }
        catch (Exception ex)
        {
            throw new JsonException("", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        // Schreib den decimal-Wert als String in JSON
        writer.WriteStringValue(value.ToString(Convertification.CultureInfo));
    }
}