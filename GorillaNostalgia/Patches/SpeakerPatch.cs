using HarmonyLib;

namespace GorillaNostalgia.Patches
{
    [HarmonyPatch]
    public static class SpeakerPatch
    {
        [HarmonyPatch(typeof(GorillaSpeakerLoudness), "UpdateLoudness"), HarmonyPrefix]
        public static bool UpdateLoudnessPatch() => !Plugin.RemoveMouthAnimations.Value;

        [HarmonyPatch(typeof(GorillaSpeakerLoudness), "UpdateSmoothedLoudness"), HarmonyPrefix]
        public static bool UpdateSmoothedLoudnessPatch() => !Plugin.RemoveMouthAnimations.Value;
    }
}
