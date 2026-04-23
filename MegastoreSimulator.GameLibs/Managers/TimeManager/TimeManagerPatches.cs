using HarmonyLib;
using InternalTimeManager = MegastoreSimulator.GameLibs.Managers.TimeManager.TimeManager;

namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

internal class TimeManagerPatches
{
    [HarmonyPatch(typeof(global::TimeManager), nameof(global::TimeManager.Awake))]
    internal static class AwakePatches
    {
        [HarmonyPostfix]
        static void Postfix(global::TimeManager __instance)
        {
            Logger.LogDebug($"### Awake");
            InternalTimeManager.Instance = __instance;
        }
    }

    [HarmonyPatch(typeof(global::TimeManager), nameof(global::TimeManager.OnEndDay))]
    internal static class OnDayEndPatches
    {
        [HarmonyPostfix]
        static void Postfix()
        {
            Logger.LogDebug($"### OnDayEnd");
            TimeManagerEvents.FireOnDayEnd();
        }
    }

    [HarmonyPatch(typeof(global::TimeManager), nameof(global::TimeManager.StartTheNewDay))]
    internal static class OnStartTheNewDay
    {
        [HarmonyPostfix]
        static void Postfix(global::TimeManager __instance)
        {
            Logger.LogDebug($"### OnNewDayStart");
            TimeManagerEvents.FireOnDayStart();
        }
    }
}
