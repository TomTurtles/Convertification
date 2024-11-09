namespace Convertification;

public static class DateTimeExtensions
{
    /// <summary>
    /// Unix Seconds
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static long ToUnix(this DateTime dateTime)
    {
        try
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime.ToUniversalTime());
            return dateTimeOffset.ToUnixTimeSeconds();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to Unix timestamp.", ex);
        }
    }

    public static long ToUnixMilliseconds(this DateTime dateTime)
    {
        try
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime.ToUniversalTime());
            return dateTimeOffset.ToUnixTimeMilliseconds();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to Unix milliseconds.", ex);
        }
    }

    public static DateTime ToStartOfDay(this DateTime dateTime)
    {
        try
        {
            return dateTime.Date;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to the start of the day.", ex);
        }
    }

    public static DateTime ToEndOfDay(this DateTime dateTime)
    {
        try
        {
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to the end of the day.", ex);
        }
    }

    public static string ToIso8601String(this DateTime dateTime)
    {
        try
        {
            return dateTime.ToString("o"); // ISO 8601 Format
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to ISO 8601 string.", ex);
        }
    }

    public static string ToFriendlyDateString(this DateTime dateTime)
    {
        try
        {
            var now = DateTime.Now;
            if (dateTime.Date == now.Date)
            {
                return "Today";
            }
            if (dateTime.Date == now.Date.AddDays(-1))
            {
                return "Yesterday";
            }
            if (dateTime.Date > now.Date.AddDays(-7))
            {
                return $"{(now.Date - dateTime.Date).Days} days ago";
            }
            return dateTime.ToString("MMMM dd, yyyy");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to a friendly date string.", ex);
        }
    }
    public static string ToSqlString(this DateTime dateTime)
    {
        try
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to convert '{dateTime}' to SQL string format.", ex);
        }
    }
}
