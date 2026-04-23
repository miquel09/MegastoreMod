using System;
using InternalTimeManager = MegastoreSimulator.GameLibs.Managers.TimeManager.TimeManager;

namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

public static class TimeManagerEvents
{
    public static event Action<InternalTimeManager> OnDayEnd;
    internal static void FireOnDayEnd(InternalTimeManager self) => OnDayEnd?.Invoke(self);

    public static event Action<InternalTimeManager> OnNewDayStart;
    internal static void FireOnNewDayStart(InternalTimeManager self) => OnNewDayStart?.Invoke(self);
}
