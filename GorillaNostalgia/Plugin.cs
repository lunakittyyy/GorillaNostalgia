using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;
using Utilla;

namespace GorillaNostalgia
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public static ConfigEntry<bool> useEarlyAccessCosmetics;
        public static ConfigEntry<bool> removeRocket;
        public static ConfigEntry<bool> removeMouthAnimations;

        void Start()
        {
            useEarlyAccessCosmetics = Config.Bind("Cosmetics", "UseEarlyAccessCosmetics", true, "Limit the cosmetics in the game to the ones in the Early Access DLC.");
            removeRocket = Config.Bind("Players", "RemoveMouthAnimations", true, "Removes the speaking animations from player faces.");
            removeRocket = Config.Bind("Maps", "RemoveRocket", true, "Removes the rocket from City.");
            HarmonyPatches.ApplyHarmonyPatches();

            if (removeRocket.Value)
            {
                Destroy(GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/RocketShip_IdleDummy"));
                Destroy(GameObject.Find("Environment Objects/05Maze_PersistientObjects/RocketShip_Prefab"));
            }
        }
    }
}
