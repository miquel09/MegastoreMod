using HarmonyLib;
using InternalShelf = MegastoreSimulator.GameLibs.Models.Shelf;
using InternalStockManager = MegastoreSimulator.GameLibs.Managers.StockManager.StockManager;
using InternalProductType = MegastoreSimulator.GameLibs.Models.Enums.ProductType;
using InternalProductGroup = MegastoreSimulator.GameLibs.Models.Enums.ProductGroup;

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


    [HarmonyPatch(typeof(global::StockManager), nameof(global::StockManager.OnProductAdded))]
    internal static class OnProductAddedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::Shelf __0, global::ProductType __1)
        {
            Logger.LogDebug("### OnProductAdded");
            var shelf = new InternalShelf(__0);
            var productType = (InternalProductType)(int)__1;
            StockManagerEvents.FireOnProductAddedToShelf(shelf, productType);
        }
    }

    [HarmonyPatch(typeof(global::StockManager), nameof(global::StockManager.OnProductRemoved))]
    internal static class OnProductRemovedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::Shelf __0, global::ProductType __1)
        {
            Logger.LogDebug("### OnProductRemoved");
            var shelf = new InternalShelf(__0);
            var productType = (InternalProductType)(int)__1;
            StockManagerEvents.FireOnProductRemoved(shelf, productType);
        }
    }

    [HarmonyPatch(typeof(global::StockManager), nameof(global::StockManager.OnProductAddedToBox))]
    internal static class OnProductAddedToBoxPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::ProductType __0, int __1)
        {
            Logger.LogDebug("### OnProductAddedToBox");
            var productType = (InternalProductType)(int)__0;
            StockManagerEvents.FireOnProductAddedToBox(productType, __1);
        }
    }

    [HarmonyPatch(typeof(global::StockManager), nameof(global::StockManager.OnProductPriceChanged))]
    internal static class OnProductPriceChangedPatches
    {
        [HarmonyPostfix]
        static void Postfix(global::ProductType __0, float __1)
        {
            Logger.LogDebug("### OnProductPriceChanged");
            var productType = (InternalProductType)(int)__0;
            StockManagerEvents.FireOnProductPriceChanged(productType, __1);
        }
    }


    [HarmonyPatch(typeof(global::StockManager), nameof(global::StockManager.OnLicensePurchased))]
    internal static class OnLicensePurchasedPatches
    {
        [HarmonyPostfix]
        static void Postfix(int __0, global::ProductGroup __1)
        {
            Logger.LogDebug("### OnLicensePurchased");
            var productGroup = (InternalProductGroup)(int)__1;
            StockManagerEvents.FireOnLicensePurchased(__0, productGroup);
        }
    }
}
