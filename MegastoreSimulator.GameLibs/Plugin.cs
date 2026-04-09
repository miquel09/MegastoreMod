using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace MegastoreSimulator.GameLibs;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private Harmony _harmony;

    private void Awake()
    {
        Logger = base.Logger;
        MapsterConfig.Register();
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll(typeof(Plugin).Assembly);
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void OnDestroy()
    {
        _harmony?.UnpatchSelf();
    }
}
