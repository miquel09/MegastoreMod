using HarmonyLib;
using InternalCheckoutManager = MegastoreSimulator.GameLibs.Managers.CheckoutManager.CheckoutManager;

namespace MegastoreSimulator.GameLibs.Managers.CheckoutManager;

internal class CheckoutManagerPatches
{
    #region Payment
    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.OnPaymentFinished))]
    internal static class OnPaymentFinishedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance, float __0)
        {
            Plugin.Logger.LogDebug($"### OnPaymentFinished");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnPaymentFinished(instance, __0);
        }
    }
    #endregion

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.OnLeaveStarted))]
    internal static class OnLeaveStartedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance, float __0)
        {
            Plugin.Logger.LogDebug($"### OnCustomerLeftQueue");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnCustomerLeftQueue(instance);
        }
    }
}
