using HarmonyLib;
using Submerge.Utilities;

namespace Submerge.Hooking;

[HarmonyPatch(typeof(global::Player))]
public class PlayerPatches
{
    [HarmonyPatch(typeof(global::Player), "Awake")]
    public class PlayerAwake
    {
        private static void Postfix(global::Player __instance)
        {
            if (!LocalPlayer.localPlayer)
                LocalPlayer.localPlayer = __instance;
        }
    }
}