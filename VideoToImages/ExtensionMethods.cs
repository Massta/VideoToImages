using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public static class ExtensionMethods
{
    #region string Methods


    public static int? ToInt(this string input)
    {
        return int.TryParse(input, out var tempVal) ? tempVal : (int?)null;
    }

    public static decimal? ToDecimal(this string input)
    {
        return decimal.TryParse(input, out var tempVal) ? tempVal : (decimal?)null;
    }

    public static double? ToDouble(this string input)
    {
        return double.TryParse(input, out var tempVal) ? tempVal : (double?)null;
    }

    public static float? ToFloat(this string input)
    {
        return float.TryParse(input, out var temVal) ? temVal : (float?)null;
    }

    public static string ToJsonString(this object input)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(input);
    }

    public static bool IsNullOrEmpty(this string input)
    {
        return string.IsNullOrEmpty(input);
    }

    /// <summary>
    /// https://stackoverflow.com/questions/2642141/how-to-create-deterministic-guids/5657517
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Guid ToGuid(this string source)
    {
        byte[] stringbytes = Encoding.UTF8.GetBytes(source);
        byte[] hashedBytes = new System.Security.Cryptography
            .SHA1CryptoServiceProvider()
            .ComputeHash(stringbytes);
        Array.Resize(ref hashedBytes, 16);
        return new Guid(hashedBytes);
    }

    public static string ToHexColor(this string source)
    {
        var guid = source.ToGuid().ToString();
        return guid.Substring(0, 6);

    }

    public static string ToCleanCSVString(this string input, string defaultIfEmpty = "")
    {
        if (string.IsNullOrEmpty(input))
        {
            return defaultIfEmpty;
        }
        return input.Replace(";", ",")
                    .Replace(";", ",")
                    .Replace("\r\n", " ")
                    .Replace("\r", " ")
                    .Replace("\n", " ");
    }

    #endregion

    #region DateTime Methods

    // This presumes that weeks start with Monday.
    // Week 1 is the 1st week of the year with a Thursday in it.
    public static int GetIso8601WeekOfYear(this DateTime time)
    {
        // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
        // be the same week# as whatever Thursday, Friday or Saturday are,
        // and we always get those right
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            time = time.AddDays(3);
        }

        // Return the week of our adjusted day
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static int CalculateAge(this DateTime birthDate)
    {
        DateTime now = DateTime.Now;
        int age = now.Year - birthDate.Year;

        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            age--;

        return age;
    }

    #endregion

    #region Collection Methods

    public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
    {
        return collection == null || !collection.Any();
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
    {
        return collection == null || !collection.Any();
    }

    #endregion

    #region Type Methods

    public static T GetDefaultValue<T>()
    {
        // We want an Func<T> which returns the default.
        // Create that expression here.
        Expression<Func<T>> e = Expression.Lambda<Func<T>>(
            // The default value, always get what the *code* tells us.
            Expression.Default(typeof(T))
        );

        // Compile and return the value.
        return e.Compile()();
    }

    public static object GetDefaultValue(this Type type)
    {
        // Validate parameters.
        if (type == null) throw new ArgumentNullException("type");

        // We want an Func<object> which returns the default.
        // Create that expression here.
        Expression<Func<object>> e = Expression.Lambda<Func<object>>(
            // Have to convert to object.
            Expression.Convert(
                // The default value, always get what the *code* tells us.
                Expression.Default(type), typeof(object)
            )
        );

        // Compile and return the value.
        return e.Compile()();
    }

    #endregion
}
