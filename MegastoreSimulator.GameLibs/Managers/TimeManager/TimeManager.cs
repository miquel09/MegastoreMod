using System;

namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

public static class TimeManager
{
    internal static global::TimeManager Instance { private get; set; }

    public static int CurrentDay
    {
        get
        {
            if(Instance == null)
                throw new InvalidOperationException("TimeManager is not yet initialised")
            return Instance.CurrentDay; 
        }
    }
}
