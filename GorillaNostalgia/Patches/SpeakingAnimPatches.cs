using HarmonyLib;
using UnityEngine;

namespace GorillaNostalgia.Patches
{
    public class SpeakingAnimPatches
    {
        [HarmonyPatch(typeof(GorillaSpeakerLoudness))]
        public static class SpeakerPatches
        {
            [HarmonyPrefix, HarmonyPatch("UpdateLoudness")]
            public static bool LoudnessPatch() => !Plugin.RemoveMouthAnimations.Value;

            [HarmonyPrefix, HarmonyPatch("UpdateSmoothedLoudness")]
            public static bool SmoothLoudnessPatch() => !Plugin.RemoveMouthAnimations.Value;
        }

        [HarmonyPatch(typeof(GorillaMouthFlap), "InvokeUpdate")]
        public static class MouthPatches
        {
            public static bool Prefix(GorillaMouthFlap __instance)
            {
                return !Plugin.RemoveMouthAnimations.Value;
            }
        }
    }
}
