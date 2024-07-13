using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;
using HarmonyLib;

namespace GorillaNostalgia
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> UseEarlyAccessDLC;
        public static ConfigEntry<bool> RemoveRocketObject;
        public static ConfigEntry<bool> RemoveMouthAnimations;

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, PluginInfo.GUID);

            GorillaTagger.OnPlayerSpawned(InitializeObjects);
            InitializeConfig();
        }

        public void InitializeConfig()
        {
            UseEarlyAccessDLC = Config.Bind("Cosmetics", "UseEarlyAccessCosmetics", false, "Limit the cosmetics in the game to the ones in the Early Access DLC.");
            RemoveRocketObject = Config.Bind("Players", "RemoveMouthAnimations", true, "Removes the speaking animations from player faces.");
            RemoveRocketObject = Config.Bind("Maps", "RemoveRocket", true, "Removes the rocket from City.");
        }

        public void InitializeObjects()
        {
            try
            {
                if (RemoveRocketObject.Value)
                {
                    Destroy(GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/RocketShip_IdleDummy"));
                    Destroy(GameObject.Find("Environment Objects/05Maze_PersistientObjects/RocketShip_Prefab"));
                }
            }
            catch(Exception ex)
            {
                Logger.LogError($"Error for initializing objects: {ex}");
            }
        }
    }
}
