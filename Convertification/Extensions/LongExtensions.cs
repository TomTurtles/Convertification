namespace Convertification;

public static class LongExtensions
{
    public static int ToInteger(this long value, int? defaultValue = null)
    {
        try
        {
            if (value < int.MinValue || value > int.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{value}' to an integer. Value is out of range.");
            }
            return Convert.ToInt32(value, Convertification.CultureInfo);
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

    public static short ToShort(this long value, short? defaultValue = null)
    {
        try
        {
            if (value < short.MinValue || value > short.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{value}' to a short. Value is out of range.");
            }
            return Convert.ToInt16(value, Convertification.CultureInfo);
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

    public static byte ToByte(this long value, byte? defaultValue = null)
    {
        try
        {
            if (value < byte.MinValue || value > byte.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{value}' to a byte. Value is out of range.");
            }
            return Convert.ToByte(value, Convertification.CultureInfo);
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

    public static sbyte ToSByte(this long value, sbyte? defaultValue = null)
    {
        try
        {
            if (value < sbyte.MinValue || value > sbyte.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{value}' to an sbyte. Value is out of range.");
            }
            return Convert.ToSByte(value, Convertification.CultureInfo);
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

    public static uint ToUInt(this long value, uint? defaultValue = null)
    {
        try
        {
            if (value < uint.MinValue || value > uint.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{value}' to a uint. Value is out of range.");
            }
            return Convert.ToUInt32(value, Convertification.CultureInfo);
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

    public static ulong ToULong(this long value, ulong? defaultValue = null)
    {
        try
        {
            if (value < 0)
            {
                throw new OverflowException($"Cannot convert '{value}' to a ulong. Value is negative.");
            }
            return Convert.ToUInt64(value, Convertification.CultureInfo);
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

    public static float ToFloat(this long value, float? defaultValue = null)
    {
        try
        {
            return Convert.ToSingle(value, Convertification.CultureInfo);
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

    public static double ToDouble(this long value, double? defaultValue = null)
    {
        try
        {
            return Convert.ToDouble(value, Convertification.CultureInfo);
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

    public static decimal ToDecimal(this long value, decimal? defaultValue = null)
    {
        try
        {
            return Convert.ToDecimal(value, Convertification.CultureInfo);
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

    public static DateTime AsUnixDateTime(this long value)
    {
        try
        {
            return DateTimeOffset.FromUnixTimeSeconds(value).UtcDateTime;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{value}' to a Unix DateTime.", ex);
        }
    }
    public static DateTime AsUnixMillisecondsDateTime(this long value)
    {
        try
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(value).UtcDateTime;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{value}' to a Unix DateTime.", ex);
        }
    }
}
