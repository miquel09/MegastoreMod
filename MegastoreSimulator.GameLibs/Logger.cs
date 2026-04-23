namespace MegastoreSimulator.GameLibs;

internal static class Logger
{
    public static void Log(string logLine)
    {
        Plugin.Logger.LogInfo(logLine);
    }

    public static void LogDebug(string logLine)
    {
#if DEBUG
        Plugin.Logger.LogDebug(logLine);
#endif
    }
}
