using HarmonyLib;
using Submerge.Player;

namespace Submerge.Patches;

[HarmonyPatch(typeof(global::Player))]
public class PlayerPatches
{
    [HarmonyPatch(typeof(global::Player), "Awake")]
    public class PlayerAwake
    {
        private static void Postfix(global::Player __instance)
        {
            if (LocalPlayer.localPlayer != null)
                LocalPlayer.localPlayer = __instance;
        }
    }
}