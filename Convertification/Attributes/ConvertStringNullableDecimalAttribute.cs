namespace Convertification.Attributes;

public class ConvertStringNullableDecimalAttribute : JsonConverterAttribute
{
    public ConvertStringNullableDecimalAttribute() : base(typeof(StringNullableDecimalConverter))
    {

    }
}

public class StringNullableDecimalConverter : JsonConverter<decimal?>
{
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    var stringValue = reader.GetString();
                    return string.IsNullOrWhiteSpace(stringValue) ? null : stringValue.ToDecimal();

                case JsonTokenType.Number:
                    return reader.GetDecimal();

                case JsonTokenType.None:
                case JsonTokenType.Null:
                    return null;

                case JsonTokenType.StartObject:
                case JsonTokenType.EndObject:
                case JsonTokenType.StartArray:
                case JsonTokenType.EndArray:
                case JsonTokenType.PropertyName:
                case JsonTokenType.Comment:
                case JsonTokenType.True:
                case JsonTokenType.False:
                default:
                    throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}");
            }
        }
        catch (Exception ex)
        {
            throw new JsonException("", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue(value.Value.ToString(Convertification.CultureInfo));
        }
    }
}