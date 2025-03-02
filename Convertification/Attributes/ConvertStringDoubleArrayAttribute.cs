namespace Convertification.Attributes;

public class ConvertStringDoubleArrayAttribute : JsonConverterAttribute
{
    private readonly string _delimiter;

    public ConvertStringDoubleArrayAttribute(string delimiter = ";") : base(typeof(StringDoubleArrayConverter))
    {
        _delimiter = delimiter;
    }

    public override JsonConverter CreateConverter(Type typeToConvert)
    {
        if (typeToConvert != typeof(double[]))
        {
            throw new InvalidOperationException($"ConvertStringDoubleArrayAttribute kann nur auf double[] angewendet werden, nicht auf {typeToConvert}.");
        }

        return new StringDoubleArrayConverter(_delimiter);
    }
}

public class StringDoubleArrayConverter : JsonConverter<double[]>
{
    private readonly string _delimiter;

    public StringDoubleArrayConverter(string delimiter)
    {
        _delimiter = delimiter;
    }

    public override double[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => [
                    .. reader
                        .GetString()!
                        .Split(_delimiter, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.ToDouble())
                ],
                JsonTokenType.Number => [reader.GetDouble()],
                _ => throw new InvalidOperationException($"Unexpected JsonTokenType: {reader.TokenType}"),
            };
        }
        catch (Exception ex)
        {
            throw new JsonException("Fehler beim Konvertieren des Wertes.", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, double[] value, JsonSerializerOptions options)
    {
        var stringValue = string.Join(_delimiter, value.Select(v => v.ToString(Convertification.CultureInfo)));
        writer.WriteStringValue(stringValue);
    }
}