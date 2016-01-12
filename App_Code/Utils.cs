using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    public static string Ordinal(this int number)
    {
        const string TH = "th";
        var s = number.ToString();

        number %= 100;

        if ((number >= 11) && (number <= 13))
        {
            return s + TH;
        }

        switch (number % 10)
        {
            case 1:
                return s + "st";
            case 2:
                return s + "nd";
            case 3:
                return s + "rd";
            default:
                return s + TH;
        }
    }
}
