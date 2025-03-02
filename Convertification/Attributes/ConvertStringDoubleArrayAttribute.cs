namespace Convertification.Attributes;

public class ConvertStringDoubleArrayAttribute : JsonConverterAttribute
{
    public ConvertStringDoubleArrayAttribute() : base(typeof(StringDoubleArrayConverter))
    {
    }
}

public class StringDoubleArrayConverter : JsonConverter<double[]>
{
    private readonly string _delimiter = ",";

    public override double[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {

            return reader.TokenType switch
            {
                JsonTokenType.String => [
                    .. reader
                        .GetString()!
                        .Split(_delimiter)
                        .Select(s => s.ToDouble(double.NaN))
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