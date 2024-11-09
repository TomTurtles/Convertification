namespace Convertification;

public static class EnumExtensions
{
    public static int ToInteger<T>(this T input) where T : Enum
    {
        return Convert.ToInt32(input, Convertification.CultureInfo);
    }

    /// <summary>
    /// Returns the description if the enum element has a [Description] attribute. 
    /// If there is no description, the name of the enum value is returned.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string ToDescriptionString<T>(this T input) where T : Enum
    {
        try
        {
            FieldInfo fieldInfo = input.GetType().GetField(input.ToString());
            if (fieldInfo != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            return input.ToString();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to get description for '{input}'.", ex);
        }
    }
}
