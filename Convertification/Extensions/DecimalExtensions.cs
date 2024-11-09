namespace Convertification;

public static class DecimalExtensions
{
    public static int ToInteger(this decimal input, int? defaultValue = null)
    {
        try
        {
            if (input < int.MinValue || input > int.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to an integer. Value is out of range.");
            }
            return Convert.ToInt32(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to an integer.", ex);
        }
    }

    public static long ToLong(this decimal input, long? defaultValue = null)
    {
        try
        {
            if (input < long.MinValue || input > long.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a long. Value is out of range.");
            }
            return Convert.ToInt64(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a long.", ex);
        }
    }

    public static short ToShort(this decimal input, short? defaultValue = null)
    {
        try
        {
            if (input < short.MinValue || input > short.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a short. Value is out of range.");
            }
            return Convert.ToInt16(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a short.", ex);
        }
    }

    public static double ToDouble(this decimal input, double? defaultValue = null)
    {
        try
        {
            return Convert.ToDouble(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a double.", ex);
        }
    }

    public static float ToFloat(this decimal input, float? defaultValue = null)
    {
        try
        {
            return Convert.ToSingle(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a float.", ex);
        }
    }

    public static byte ToByte(this decimal input, byte? defaultValue = null)
    {
        try
        {
            if (input < byte.MinValue || input > byte.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a byte. Value is out of range.");
            }
            return Convert.ToByte(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a byte.", ex);
        }
    }

    public static sbyte ToSByte(this decimal input, sbyte? defaultValue = null)
    {
        try
        {
            if (input < sbyte.MinValue || input > sbyte.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to an sbyte. Value is out of range.");
            }
            return Convert.ToSByte(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to an sbyte.", ex);
        }
    }

    public static uint ToUInt(this decimal input, uint? defaultValue = null)
    {
        try
        {
            if (input < uint.MinValue || input > uint.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a uint. Value is out of range.");
            }
            return Convert.ToUInt32(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a uint.", ex);
        }
    }

    public static ulong ToULong(this decimal input, ulong? defaultValue = null)
    {
        try
        {
            if (input < ulong.MinValue || input > ulong.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a ulong. Value is out of range.");
            }
            return Convert.ToUInt64(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a ulong.", ex);
        }
    }

    public static ushort ToUShort(this decimal input, ushort? defaultValue = null)
    {
        try
        {
            if (input < ushort.MinValue || input > ushort.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a ushort. Value is out of range.");
            }
            return Convert.ToUInt16(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a ushort.", ex);
        }
    }

    public static bool ToBoolean(this decimal input, bool? defaultValue = null)
    {
        try
        {
            return input != 0m;
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a boolean.", ex);
        }
    }

    public static char ToChar(this decimal input, char? defaultValue = null)
    {
        try
        {
            if (input < char.MinValue || input > char.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a char. Value is out of range.");
            }
            return Convert.ToChar((int)input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a char.", ex);
        }
    }

    public static DateTime ToDateTime(this decimal input, DateTime? defaultValue = null)
    {
        try
        {
            return new DateTime(Convert.ToInt64(input, Convertification.CultureInfo));
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a DateTime. Value is out of the valid DateTime range.", ex);
        }
    }

    public static TimeSpan ToTimeSpan(this decimal input, TimeSpan? defaultValue = null)
    {
        try
        {
            return TimeSpan.FromSeconds(Convert.ToDouble(input, Convertification.CultureInfo));
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a TimeSpan.", ex);
        }
    }
}
