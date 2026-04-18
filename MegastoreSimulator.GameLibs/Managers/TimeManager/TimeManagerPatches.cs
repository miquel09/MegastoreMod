using HarmonyLib;
using InternalTimeManager = MegastoreSimulator.GameLibs.Managers.TimeManager.TimeManager;

namespace MegastoreSimulator.GameLibs.Managers.TimeManager;

internal class TimeManagerPatches
{
    [HarmonyPatch(typeof(global::TimeManager), nameof(global::TimeManager.OnEndDay))]
    internal static class OnDayEndPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::TimeManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnDayEnd");
            var instance = new InternalTimeManager(__instance);
            TimeManagerEvents.FireOnDayEnd(instance);
        }
    }

    [HarmonyPatch(typeof(global::TimeManager), nameof(global::TimeManager.StartTheNewDay))]
    internal static class OnPaymentTakenPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::TimeManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnNewDayStart");
            var instance = new InternalTimeManager(__instance);
            TimeManagerEvents.FireOnNewDayStart(instance);
        }
    }
}
