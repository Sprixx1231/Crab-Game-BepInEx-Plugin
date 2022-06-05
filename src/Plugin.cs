using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using UnityEngine;
using UnhollowerRuntimeLib;

using CrabGamePlugin.components;

namespace CrabGamePlugin
{
    [BepInPlugin("com.Sprixx1231.CrabGameCheat", "Crab Game Menu", PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Crab Game.exe")]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;

        public override void Load()
        {
            // Plugin startup logic
            Log = base.Log;

           // ClassInjector.RegisterTypeInIl2Cpp<Esp>();
            ClassInjector.RegisterTypeInIl2Cpp<Cheat>();

            GameObject crabMenu = new GameObject(); 
            
            crabMenu.name = "Crab Menu by SpreadMouse#1121";
            //crabMenu.AddComponent<Esp>();
            crabMenu.AddComponent<Cheat>();
            crabMenu.hideFlags = HideFlags.HideAndDontSave;
            
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            
        }
    }
}
