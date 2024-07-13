﻿using HarmonyLib;

namespace GorillaNostalgia.Patches
{
    [HarmonyPatch]
    public static class SpeakerPatch
    {
        [HarmonyPatch(typeof(GorillaSpeakerLoudness), "InvokeUpdate"), HarmonyPrefix]
        public static bool UpdateLoudnessPatch() => false;

        [HarmonyPatch(typeof(GorillaSpeakerLoudness), "UpdateSmoothedLoudness"), HarmonyPrefix]
        public static bool UpdateSmoothedLoudnessPatch() => false;
    }
}