namespace Backend;

public class Time
{
    // Fielas
    private int _hour; 
    private int _minute;
    private int _second;
    private int _millisecond;


    // Constructors
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second= second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    // Properties
    public int Hour 
    { 
        get => _hour; 
        set => _hour = ValidHour(value); 
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }

    // Public Methods
    public override string ToString()
    {
        int hour12 = Hour % 12;

        string period = Hour >= 12 ? "PM" : "AM";

        return $"{hour12:D2}:{Minute:D2}:{Second:D2}.{Millisecond:D3} {period}";
    }

    public int ToMinutes()
    {
        int result = _hour * 60 + _minute;
        return result;
    }

    public int ToSeconds()
    {
        int result = _hour * 3600 + _minute * 60 + _second;
        return result;
    }

    public int ToMilliseconds()
    {
        int result = _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
        return result;
    }
    
    public Time Add(Time other)

    {
        int millisecond = _millisecond + other._millisecond;
        int carrySecond = millisecond / 1000;
        millisecond%=1000;

        int second = _second + other._second + carrySecond;
        int carryMinute = second / 60;
        second %=60;

        int minute = _minute + other._minute + carryMinute;
        int carryHour = minute / 60;
        minute %= 60;

        int hour = _hour + other._hour + carryHour;
        hour %= 24;

        return new Time(hour, minute, second, millisecond);
    }

    public bool IsOtherDay(Time other)
    {
        int millisecond = _millisecond + other._millisecond;
        int carrySecond = millisecond / 1000;

        int second = _second + other._second + carrySecond;
        int carryMinute = second / 60;

        int minute = _minute + other._minute + carryMinute;
        int carryHour = minute / 60;

        int hour = _hour + other._hour + carryHour;

        return hour >= 24;
    }

    // Private Methods
    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour :{hour} , is not valid.");
        }
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute :{minute} , is not valid.");
        }
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second :{second} , is not valid.");
        }
        return second;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond :{millisecond} , is not valid.");
        }
        return millisecond;
    }
}

