using HarmonyLib;
using UnityEngine;

namespace GorillaNostalgia.Patches
{
    public class SpeakingAnimPatches
    {
        [HarmonyPatch(typeof(GorillaSpeakerLoudness))]
        [HarmonyPatch("InvokeUpdate")]
        public static class LoudnessPatch
        {
            public static bool Prefix(GorillaSpeakerLoudness __instance)
            {
                return !Plugin.removeMouthAnimations.Value;
            }
        }

        [HarmonyPatch(typeof(GorillaMouthFlap))]
        [HarmonyPatch("InvokeUpdate")]
        public static class MouthFlapPatch
        {
            public static bool Prefix(GorillaMouthFlap __instance)
            {
                return !Plugin.removeMouthAnimations.Value;
            }
        }
    }
}
