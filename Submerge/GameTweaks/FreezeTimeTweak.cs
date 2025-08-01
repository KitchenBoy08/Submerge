using HarmonyLib;

using UWE;

namespace Submerge.GameTweaks;

[HarmonyPatch(typeof(FreezeTime))]
public class FreezeTimeTweak : GameTweak
{
    private static readonly HashSet<FreezeTime.Id> allowedFreezeIds = new HashSet<FreezeTime.Id> { FreezeTime.Id.WaitScreen, FreezeTime.Id.Quit };
    
    [HarmonyPatch(nameof(FreezeTime.Set))]
    [HarmonyPrefix]
    private static bool Set(FreezeTime.Id id)
    {
        return allowedFreezeIds.Contains(id);
    }
}