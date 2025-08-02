using MelonLoader.Utils;
using Submerge.Utilities;

namespace Submerge.Network;

public class SteamAPILoader
{
    internal static void Load()
    {
        // Load file from embedded assets
        using var stream = Core.SubmergeAssembly.GetManifestResourceStream("Submerge.Resources.steam_api64.dll");
        var targetPath = Path.Combine(MelonEnvironment.GameRootDirectory, "Subnautica_Data/Plugins/x86_64/steam_api64.dll");

        // Copy to game's path
        using var fileStream = new FileStream(targetPath, FileMode.OpenOrCreate);
        stream?.CopyTo(fileStream);
    }
}