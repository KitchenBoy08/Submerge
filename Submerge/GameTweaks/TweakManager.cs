using System.Reflection;
using Submerge.Utilities;

namespace Submerge.GameTweaks;

public class TweakManager
{
    internal static List<GameTweak> Tweaks = new List<GameTweak>();
    
    internal static void LoadInternalTweaks()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        LoadFromAssembly(assembly);
    }

    public static void LoadFromAssembly(Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            if (type.FullName.Contains("System") || type.FullName.Contains("Mono"))
                continue;
            
            if (!typeof(GameTweak).IsAssignableFrom(type) || type.IsAbstract || type.IsInterface)
                continue;
            
#if DEBUG
            Logger.Log($"Adding tweak: {type.Name}");
#endif
            
            var tweak = (GameTweak)Activator.CreateInstance(type);
            tweak.Initialize();
            
            Tweaks.Add(tweak);
        }
    }
}