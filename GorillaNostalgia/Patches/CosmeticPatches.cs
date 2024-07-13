using HarmonyLib;
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

        [HarmonyPatch(typeof(VRRig), "IsItemAllowed")]
        public static class AllowedPatch 
        {
            public static bool Prefix(ref string itemName) => EACosmetics.Contains(itemName) || !Plugin.UseEarlyAccessDLC.Value;
        }
    }
}
