using System;
using System.IO;
using System.Reflection;

using MelonLoader;
using MelonLoader.Utils;
using Steamworks;
using Submerge.GameTweaks;
using Submerge.Hooking;
using Submerge.Network;
using Submerge.Utilities;

[assembly: MelonInfo(typeof(Submerge.Core), "Submerge", "1.0.0", "Silverware", null)]
[assembly: MelonGame("Unknown Worlds", "Subnautica")]

namespace Submerge;

public class Core : MelonMod
{
    internal static Assembly SubmergeAssembly = Assembly.GetExecutingAssembly();
    
    public override void OnInitializeMelon()
    {
        Logger.InitializeLogger(LoggerInstance);
        
        // Add Game Tweaks
        TweakManager.InitializeTweaks();
    }

    public override void OnLateInitializeMelon()
    {
        // Initialize Network Layers
        NetworkLayerManager.InitializeLayers();
    }
}