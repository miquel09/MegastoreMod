using HarmonyLib;
using InternalStockManager = MegastoreSimulator.GameLibs.Managers.StockManager.StockManager;

namespace MegastoreSimulator.GameLibs.Managers.StockManager;

internal class StockManagerPatches
{
    [HarmonyPatch(typeof(global::StockManager), nameof(global::StockManager.Awake))]
    internal static class AwakePatches
    {
        [HarmonyPostfix]
        static void Postfix(global::StockManager __instance)
        {
            Logger.LogDebug($"### Awake");
            InternalStockManager.Instance = __instance;
        }
    }
}
