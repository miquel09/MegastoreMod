using System;

namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

public static class TimeManagerEvents
{
    public static event Action OnDayEnd;
    internal static void FireOnDayEnd() => OnDayEnd?.Invoke();

    public static event Action OnDayStart;
    internal static void FireOnDayStart() => OnDayStart?.Invoke();
}
