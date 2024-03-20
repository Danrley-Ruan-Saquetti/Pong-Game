using System.Timers;

namespace Library.Utils.Interval;

public static class Interval
{
    public static Timer SetInterval(ElapsedEventHandler handler, int milliseconds = 0)
    {
        return SetTimer(handler, milliseconds, true);
    }

    public static Timer SetTimeout(ElapsedEventHandler handler, int milliseconds = 0)
    {
        return SetTimer(handler, milliseconds, false);
    }

    public static Timer SetTimer(ElapsedEventHandler handler, int milliseconds = 0, bool isRepeat = true)
    {
        Timer timer = new(milliseconds);
        timer.Elapsed += handler;
        timer.AutoReset = isRepeat;
        timer.Enabled = true;

        return timer;
    }

    public static void ClearTimer(Timer timer)
    {
        timer.Enabled = false;
    }
}