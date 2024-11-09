namespace Convertification.Attributes;

public class ConvertStringEnumAttribute : JsonConverterAttribute
{
    public ConvertStringEnumAttribute() : base(typeof(JsonStringEnumConverter))
    {

    }
}