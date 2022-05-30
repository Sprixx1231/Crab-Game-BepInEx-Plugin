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
            

           // ClassInjector.RegisterTypeInIl2Cpp<Esp>();
            ClassInjector.RegisterTypeInIl2Cpp<Cheat>();

            GameObject crabMenu = new GameObject(); 
            
            crabMenu.name = "Crab Menu by SpreadMouse#1121";
            //crabMenu.AddComponent<Esp>();
            crabMenu.AddComponent<Cheat>();
            crabMenu.hideFlags = HideFlags.HideAndDontSave;
            
        }
    }
}
