namespace Convertification;

public static class ObjectExtensions
{
    public static int ToInteger(this object value, int? defaultValue = null)
    {
        try
        {
            return Convert.ToInt32(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to an integer.", ex);
        }
    }

    public static long ToLong(this object value, long? defaultValue = null)
    {
        try
        {
            return Convert.ToInt64(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a long.", ex);
        }
    }

    public static short ToShort(this object value, short? defaultValue = null)
    {
        try
        {
            return Convert.ToInt16(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a short.", ex);
        }
    }

    public static byte ToByte(this object value, byte? defaultValue = null)
    {
        try
        {
            return Convert.ToByte(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a byte.", ex);
        }
    }

    public static sbyte ToSByte(this object value, sbyte? defaultValue = null)
    {
        try
        {
            return Convert.ToSByte(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to an sbyte.", ex);
        }
    }

    public static uint ToUInt(this object value, uint? defaultValue = null)
    {
        try
        {
            return Convert.ToUInt32(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a uint.", ex);
        }
    }

    public static ulong ToULong(this object value, ulong? defaultValue = null)
    {
        try
        {
            return Convert.ToUInt64(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a ulong.", ex);
        }
    }

    public static float ToFloat(this object value, float? defaultValue = null)
    {
        try
        {
            return Convert.ToSingle(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a float.", ex);
        }
    }

    public static double ToDouble(this object value, double? defaultValue = null)
    {
        try
        {
            return Convert.ToDouble(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a double.", ex);
        }
    }

    public static decimal ToDecimal(this object value, decimal? defaultValue = null)
    {
        try
        {
            return Convert.ToDecimal(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a decimal.", ex);
        }
    }

    public static bool ToBoolean(this object value, bool? defaultValue = null)
    {
        try
        {
            return Convert.ToBoolean(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a boolean.", ex);
        }
    }

    public static char ToChar(this object value, char? defaultValue = null)
    {
        try
        {
            return Convert.ToChar(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a char.", ex);
        }
    }

    public static DateTime ToDateTime(this object value, DateTime? defaultValue = null)
    {
        try
        {
            return Convert.ToDateTime(value);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a DateTime.", ex);
        }
    }

    public static T ToEnum<T>(this object value, T? defaultValue = null) where T : struct, Enum
    {
        try
        {
            if (Enum.TryParse(value.ToString(), true, out T result))
            {
                return result;
            }
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new ArgumentException($"'{value}' is not a valid value for {typeof(T).Name}.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{value}' to {typeof(T).Name}.", ex);
        }
    }

    public static DateTime AsUnixDateTime(this object value, DateTime? defaultValue = null)
    {
        try
        {
            if (value is long longValue)
            {
                return DateTimeOffset.FromUnixTimeSeconds(longValue).UtcDateTime;
            }
            throw new InvalidOperationException($"'{value}' is not a valid Unix seconds timestamp.");
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a Unix seconds DateTime.", ex);
        }
    }

    public static DateTime AsMillisecondsUnixDateTime(this object value, DateTime? defaultValue = null)
    {
        try
        {
            if (value is long longValue)
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(longValue).UtcDateTime;
            }
            throw new InvalidOperationException($"'{value}' is not a valid Unix milliseconds timestamp.");
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{value}' to a Unix milliseconds DateTime.", ex);
        }
    }
}
