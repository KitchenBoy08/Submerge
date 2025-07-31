using HarmonyLib;
using UWE;

namespace Submerge.Patches;

[HarmonyPatch(typeof(FreezeTime))]
public class FreezeTimePatch
{
    [HarmonyPatch(typeof(FreezeTime), "Set")]
    public class FreezeTimeSet
    {
        private static bool Prefix(FreezeTime.Id id)
        {
            return allowedFreezeIds.Contains(id);
        }
        
        private static readonly HashSet<FreezeTime.Id> allowedFreezeIds = new HashSet<FreezeTime.Id> { FreezeTime.Id.WaitScreen, FreezeTime.Id.Quit };
    }
}