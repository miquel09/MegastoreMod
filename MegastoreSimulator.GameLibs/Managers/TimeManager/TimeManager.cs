namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

public class TimeManager
{
    private readonly global::TimeManager _instance;

    public int CurrentDay => _instance.CurrentDay;

    internal TimeManager(global::TimeManager instance)
    {
        _instance = instance;
    }
}
