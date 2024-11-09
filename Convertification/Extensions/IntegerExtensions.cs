namespace Convertification;

public static class IntegerExtensions
{
    public static long ToLong(this int input, long? defaultValue = null)
    {
        try
        {
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

    public static short ToShort(this int input, short? defaultValue = null)
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

    public static double ToDouble(this int input, double? defaultValue = null)
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

    public static float ToFloat(this int input, float? defaultValue = null)
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

    public static decimal ToDecimal(this int input, decimal? defaultValue = null)
    {
        try
        {
            return Convert.ToDecimal(input, Convertification.CultureInfo);
        }
        catch (Exception ex)
        {
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new InvalidOperationException($"Failed to convert '{input}' to a decimal.", ex);
        }
    }

    public static byte ToByte(this int input, byte? defaultValue = null)
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

    public static sbyte ToSByte(this int input, sbyte? defaultValue = null)
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

    public static uint ToUInt(this int input, uint? defaultValue = null)
    {
        try
        {
            if (input < 0)
            {
                throw new OverflowException($"Cannot convert '{input}' to a uint. Value is negative.");
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

    public static ulong ToULong(this int input, ulong? defaultValue = null)
    {
        try
        {
            if (input < 0)
            {
                throw new OverflowException($"Cannot convert '{input}' to a ulong. Value is negative.");
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

    public static ushort ToUShort(this int input, ushort? defaultValue = null)
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

    public static bool ToBoolean(this int input, bool? defaultValue = null)
    {
        try
        {
            return input != 0;
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

    public static char ToChar(this int input, char? defaultValue = null)
    {
        try
        {
            if (input < char.MinValue || input > char.MaxValue)
            {
                throw new OverflowException($"Cannot convert '{input}' to a char. Value is out of range.");
            }
            return Convert.ToChar(input, Convertification.CultureInfo);
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

    public static DateTime ToDateTime(this int input, DateTime? defaultValue = null)
    {
        try
        {
            return new DateTime(input);
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

    public static TimeSpan ToTimeSpan(this int input, TimeSpan? defaultValue = null)
    {
        try
        {
            return TimeSpan.FromSeconds(input);
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

    public static T ToEnum<T>(this int input, T? defaultValue = null) where T : struct, Enum
    {
        try
        {
            if (Enum.IsDefined(typeof(T), input))
            {
                return (T)Enum.ToObject(typeof(T), input);
            }
            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }
            throw new ArgumentException($"'{input}' is not a valid value for {typeof(T).Name}.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{input}' to {typeof(T).Name}.", ex);
        }
    }
}
