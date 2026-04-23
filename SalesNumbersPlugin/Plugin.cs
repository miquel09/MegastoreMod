using BepInEx;
using BepInEx.Logging;
using MegastoreSimulator.GameLibs.Managers.CheckoutManager;
using MegastoreSimulator.GameLibs.Models;
using SalesNumbersPlugin.Managers;

namespace SalesNumbersPlugin;

[BepInDependency(MegastoreSimulator.GameLibs.MyPluginInfo.PLUGIN_GUID)]
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;
        //ComputerUiManager.AddButton(new ButtonDefinition()
        //{
        //    ButtonName = "SalesOverviewButton",
        //    DisplayText = "Sales Overview",
        //    OnClicked = ShoppingButtonClicked
        //});

        //ComputerUiManager.AddButton(new ButtonDefinition()
        //{
        //    ButtonName = "SalesOverviewButton2",
        //    DisplayText = "Sales Overview",
        //    OnClicked = ShoppingButtonClicked
        //});

        //ComputerUiManager.AddButton(new ButtonDefinition()
        //{
        //    ButtonName = "SalesOverviewButton3",
        //    DisplayText = "Sales Overview",
        //    OnClicked = ShoppingButtonClicked
        //});

        //ComputerUiManager.AddButton(new ButtonDefinition()
        //{
        //    ButtonName = "SalesOverviewButton4",
        //    DisplayText = "Sales Overview",
        //    OnClicked = ShoppingButtonClicked
        //});


        CheckoutManagerEvents.OnProductScanned += CheckoutManagerEvents_OnProductScanned;
    }

    private void ShoppingButtonClicked()
    {
        Log.LogInfo("Shopping button clicked");
    }

    private void CheckoutManagerEvents_OnProductScanned(CheckoutManager manager, Product product)
    {
        SalesNumbersManager.UpdateSalesNumbers(product.ProductType, 1);
        Log.LogInfo($"Product brand: {product.Brand}");
    }
    
}