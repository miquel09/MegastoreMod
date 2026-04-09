using BepInEx;
using BepInEx.Logging;
using MegastoreSimulator.GameLibs.Managers.CheckoutManager;
using MegastoreSimulator.GameLibs.Models;
using SalesNumbersPlugin.Managers;
using System;

namespace SalesNumbersPlugin;

[BepInDependency(MegastoreSimulator.GameLibs.MyPluginInfo.PLUGIN_GUID)]
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;
        CheckoutManagerEvents.OnProductScanned += CheckoutManagerEvents_OnProductScanned;
    }

    private void CheckoutManagerEvents_OnProductScanned(CheckoutManager manager, Product product)
    {
        SalesNumbersManager.UpdateSalesNumbers(product.ProductType, 1);
        Log.LogInfo($"Product brand: {product.Brand}");
    }
}