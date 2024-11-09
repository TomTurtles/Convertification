namespace Convertification.Attributes;

public class ConvertStringDecimalAttribute : JsonConverterAttribute
{
    public ConvertStringDecimalAttribute(): base(typeof(StringDecimalConverter))
    {
        
    }
}

public class StringDecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString()!.ToDecimal(),
                JsonTokenType.Number => reader.GetDecimal(),
                _ => throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}"),
            };
        }
        catch (Exception ex)
        {
            throw new JsonException("", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        // Schreib den decimal-Wert als String in JSON
        writer.WriteStringValue(value.ToString(Convertification.CultureInfo));
    }
}