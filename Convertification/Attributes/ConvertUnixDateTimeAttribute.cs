namespace Convertification.Attributes;

/// <summary>
/// Unix Milliseconds
/// </summary>
public class ConvertUnixDateTimeAttribute : JsonConverterAttribute
{
    public ConvertUnixDateTimeAttribute() : base(typeof(UnixDateTimeConverter))
    {

    }
}

public class UnixDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var longValue = reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString()!.ToLong(),
                JsonTokenType.Number => reader.GetInt64(),
                _ => throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}"),
            };
            return longValue.AsUnixMillisecondsDateTime();
        }
        catch (Exception ex)
        {
            throw new JsonException("", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var longValue = value.ToUnixMilliseconds();
        writer.WriteNumberValue(longValue);
    }
}