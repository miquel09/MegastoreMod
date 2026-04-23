using HarmonyLib;
using System.Linq;
using InternalCheckoutManager = MegastoreSimulator.GameLibs.Managers.CheckoutManager.CheckoutManager;
using InternalProduct = MegastoreSimulator.GameLibs.Models.Product;
using InternalCustomer = MegastoreSimulator.GameLibs.Models.Customer;
using System.Collections.Generic;

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

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.TakePayment))]
    internal static class OnPaymentTakenPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnPaymentTaken");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnPaymentTaken(instance);
        }
    }

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.TakeCashPayment))]
    internal static class OnCashPaymentTakenPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnCashPaymentTaken");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnCashPaymentTaken(instance);
        }
    }

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.TakeCardPayment))]
    internal static class OnCardPaymentTakenPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnCardPaymentTaken");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnCardPaymentTaken(instance);
        }
    }
    #endregion

    #region Products and Scanning
    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.ScanProduct), [typeof(global::Product)])]
    internal static class OnProductScannedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance, global::Product __0)
        {
            Plugin.Logger.LogDebug($"### OnProductScanned");
            var instance = new InternalCheckoutManager(__instance);
            var product = new InternalProduct(__0);
            CheckoutManagerEvents.FireOnProductScanned(instance, product);
        }
    }

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.PlaceProducts))]
    internal static class OnProductsPlacedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance, List<global::Product> __0)
        {
            Plugin.Logger.LogDebug($"### OnProductsPlaced");
            var instance = new InternalCheckoutManager(__instance);
            var products = __0.Select(p => new InternalProduct(p)).ToList();
            CheckoutManagerEvents.FireOnPlaceProducts(instance, products);
        }
    }

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.MoveToBag))]
    internal static class OnMovedToBagPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance, List<global::Product> __0, float __1)
        {
            Plugin.Logger.LogDebug($"### OnMovedToBag");
            var instance = new InternalCheckoutManager(__instance);
            var products = __0.Select(p => new InternalProduct(p)).ToList();
            CheckoutManagerEvents.FireOnMovedToBag(instance, products, __1);
        }
    }
    #endregion

    #region Queue and Customer
    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.GetIntoTheQueue))]
    internal static class OnCustomerJoinedQueuePatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance, global::Customer __0)
        {
            Plugin.Logger.LogDebug($"### OnCustomerJoinedQueue");
            var instance = new InternalCheckoutManager(__instance);
            var customer = new InternalCustomer(__0);
            CheckoutManagerEvents.FireOnCustomerJoinedQueue(instance, customer);
        }
    }

    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.OnLeaveStarted))]
    internal static class OnLeaveStartedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnCustomerLeftQueue");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnCustomerLeftQueue(instance);
        }
    }
    #endregion

    #region Checkout State
    [HarmonyPatch(typeof(global::CheckoutManager), nameof(global::CheckoutManager.SwitchClosedSign))]
    internal static class OnCheckoutStatusChangedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::CheckoutManager __instance)
        {
            Plugin.Logger.LogDebug($"### OnCheckoutStatusChanged");
            var instance = new InternalCheckoutManager(__instance);
            CheckoutManagerEvents.FireOnCheckoutStatusChanged(instance);
        }
    }
    #endregion
}
