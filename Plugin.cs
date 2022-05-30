using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using System;
using UnhollowerRuntimeLib;
using BepInEx.Configuration;
using CrabGamePlugin.components;

namespace CrabGamePlugin
{
    [BepInPlugin("com.Sprixx1231.CrabGameCheat", "Crab Game Menu", PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Crab Game.exe")]
    public class Plugin : BasePlugin
    {

        public override void Load()
        {
            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            

            ClassInjector.RegisterTypeInIl2Cpp<Esp>();
            new GameObject("EPIC HAX")
            {
                hideFlags = HideFlags.HideAndDontSave //The GameObject is not shown in the Hierarchy, not saved to to Scenes, and not unloaded by Resources.UnloadUnusedAssets.
            }.AddComponent<Esp>();
        }
    }
}
