using System;
using System.IO;
using System.Reflection;

using MelonLoader;
using MelonLoader.Utils;
using Steamworks;

[assembly: MelonInfo(typeof(Submerge.Core), "Submerge", "1.0.0", "Silverware", null)]
[assembly: MelonGame("Unknown Worlds", "Subnautica")]

namespace Submerge;

public class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        // Manually load a full steam_api64.dll for Facepunch.Steamworks support
        LoadSteamClient();
    }

    private static void LoadSteamClient()
    {
        var steamApiPath = Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll");

        var asm = Assembly.GetExecutingAssembly();
        using var steamApiResource = asm.GetManifestResourceStream("Submerge.Resources.steam_api64.dll");
        using var file = new FileStream(steamApiPath, FileMode.OpenOrCreate, FileAccess.Write);
        steamApiResource?.CopyTo(file);
        
        SteamClient.Init(480, false);

        if (!SteamClient.IsValid)
        {
            MelonLogger.Error("Failed to initialize Steam Client. Please ensure Steam is running.");
        }

        SteamNetworkingUtils.InitRelayNetworkAccess();
    }
}