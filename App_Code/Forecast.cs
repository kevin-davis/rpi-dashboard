using System;

/// <summary>
/// Summary description for Forecast
/// </summary>
public class Forecast
{
    double _dayHi, _dayLo, _tempNow;
    string _descNow, _icon;
    public string TempDay
    {
        get
        {
            return string.Format("{0}° / {1}°", Math.Round(_dayHi), Math.Round(_dayLo));
        }
    }

    public string TempNow
    {
        get
        {
            return string.Format("{0}°", Math.Round(_tempNow));
        }
    }
    public string DescNow
    {
        // If it's day time and it's "Clear" I want the UI to stay "Sunny"
        get
        {
            return _descNow == "Clear" && _icon == "clear-day" ? "Sunny" : _descNow;
        }
    }
    public string IconUrl
    {
        get
        {
            return string.Format("/Images/Weather/{0}.png", _icon);
        }
    }

    public string IconName
    {
        get
        {
            return _icon;
        }
    }
    public Forecast(double dayHi, double dayLo, double tempNow, string descNow, string icon)
    {
        _dayHi = dayHi;
        _dayLo = dayLo;
        _tempNow = tempNow;
        _descNow = descNow;
        _icon = icon;
    }

}