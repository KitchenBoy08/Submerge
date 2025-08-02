using MelonLoader.Utils;
using Submerge.Utilities;

namespace Submerge.Network;

public class SteamAPILoader
{
    internal static void Load()
    {
        // Return if SteamAPI has already been updated
        if (File.Exists(Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll.bak")))
            return;
        
        // Rename the OG SteamAPI
        if (File.Exists(Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll")))
            File.Move(Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll"), Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll.bak"));
        
        // Load file from embedded assets
        using var stream = Core.SubmergeAssembly.GetManifestResourceStream("Submerge.Resources.steam_api64.dll");
        
        // Copy to game's path
        var targetPath = Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll");
        using var fileStream = new FileStream(targetPath, FileMode.OpenOrCreate);
        stream?.CopyTo(fileStream);
    }
}