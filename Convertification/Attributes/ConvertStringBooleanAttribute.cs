namespace Convertification.Attributes;

public class ConvertStringBooleanAttribute : JsonConverterAttribute
{
    public ConvertStringBooleanAttribute(): base(typeof(StringBooleanConverter))
    {
        
    }
}

public class StringBooleanConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString().ToBoolean(),
                JsonTokenType.False => false,
                JsonTokenType.True => true,
                JsonTokenType.Number => reader.GetDouble() != 0,
                _ => throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}"),
            };
        }
        catch (Exception ex)
        {
            throw new JsonException("", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        // Schreib den decimal-Wert als String in JSON
        writer.WriteBooleanValue(value);
    }
}