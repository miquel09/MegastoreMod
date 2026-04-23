using System;

namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

public static class TimeManager
{
    private static global::TimeManager _instance;
    internal static global::TimeManager Instance
    {
        private get
        {
            if (_instance == null)
                throw new InvalidOperationException("TimeManager is not yet initialised");
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public static int CurrentDay
    {
        get
        {
            return Instance.CurrentDay; 
        }
    }
}
