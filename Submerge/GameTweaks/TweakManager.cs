using System.Reflection;
using Submerge.Utilities;

namespace Submerge.GameTweaks;

public class TweakManager
{
    internal static List<GameTweak> Tweaks = new List<GameTweak>();
    
    internal static void InitializeTweaks()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        Tweaks = AssemblyLoader.LoadTypesFromAssembly<GameTweak>(assembly);

        foreach (var tweak in Tweaks)
        {
            Logger.DebugLog($"Loaded tweak: {tweak.GetType().Name}");
            tweak.Initialize();
        }
    }
}