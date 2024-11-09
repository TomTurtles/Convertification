namespace Convertification;

public static class StringExtensions
{
    public static int ToInteger(this string input, int? defaultValue = null)
    {
        if (int.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out int result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to an integer.");
    }

    public static long ToLong(this string input, long? defaultValue = null)
    {
        if (long.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out long result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a long.");
    }

    public static short ToShort(this string input, short? defaultValue = null)
    {
        if (short.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out short result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a short.");
    }

    public static double ToDouble(this string input, double? defaultValue = null)
    {
        if (double.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out double result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a double.");
    }

    public static float ToFloat(this string input, float? defaultValue = null)
    {
        if (float.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out float result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a float.");
    }

    public static decimal ToDecimal(this string input, decimal? defaultValue = null)
    {
        if (decimal.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out decimal result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a decimal.");
    }

    public static byte ToByte(this string input, byte? defaultValue = null)
    {
        if (byte.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out byte result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a byte.");
    }

    public static sbyte ToSByte(this string input, sbyte? defaultValue = null)
    {
        if (sbyte.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out sbyte result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to an sbyte.");
    }

    public static uint ToUInt(this string input, uint? defaultValue = null)
    {
        if (uint.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out uint result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a uint.");
    }

    public static ulong ToULong(this string input, ulong? defaultValue = null)
    {
        if (ulong.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out ulong result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a ulong.");
    }

    public static ushort ToUShort(this string input, ushort? defaultValue = null)
    {
        if (ushort.TryParse(input, Convertification.NumberStyles, Convertification.CultureInfo, out ushort result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a ushort.");
    }

    public static bool ToBoolean(this string input, bool? defaultValue = null)
    {
        if (bool.TryParse(input, out bool result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a boolean.");
    }

    public static DateTime ToDateTime(this string input, DateTime? defaultValue = null)
    {
        if (DateTime.TryParse(input, out DateTime result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a DateTime.");
    }

    public static TimeSpan ToTimeSpan(this string input, TimeSpan? defaultValue = null)
    {
        if (TimeSpan.TryParse(input, out TimeSpan result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a TimeSpan.");
    }

    public static char ToChar(this string input, char? defaultValue = null)
    {
        if (char.TryParse(input, out char result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a char.");
    }

    public static Guid ToGuid(this string input, Guid? defaultValue = null)
    {
        if (Guid.TryParse(input, out Guid result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to a Guid.");
    }

    public static T ToEnum<T>(this string input, T? defaultValue = null) where T : struct
    {
        if (Enum.TryParse(input, true, out T result))
        {
            return result;
        }
        if (defaultValue.HasValue)
        {
            return defaultValue.Value;
        }
        throw new FormatException($"Cannot convert '{input}' to {typeof(T).Name}.");
    }

    public static Uri ToUri(this string input, Uri? defaultValue = null)
    {
        if (Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out Uri result))
        {
            return result;
        }
        if (defaultValue != null)
        {
            return defaultValue;
        }
        throw new FormatException($"Cannot convert '{input}' to a Uri.");
    }
}
