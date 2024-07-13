using GorillaNetworking;
using HarmonyLib;
using System;
using System.Collections.Generic;

namespace GorillaNostalgia.Patches
{

    public class CosmeticPatches
    {
        public static List<string> EACosmetics = new List<string> {
            "LBAAE.",
            "LFAAM.",
            "LFAAN.",
            "LHAAA.",
            "LHAAK.",
            "LHAAL.",
            "LHAAM.",
            "LHAAN.",
            "LHAAO.",
            "LHAAP.",
            "LHABA.",
            "LHABB."
        };

        [HarmonyPatch(typeof(VRRig))]
        [HarmonyPatch("IsItemAllowed")]
        public static class AllowedPatch {
            public static bool Prefix(ref string itemName, ref bool __result)
            {
                if (EACosmetics.Contains(itemName) || !Plugin.useEarlyAccessCosmetics.Value)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
