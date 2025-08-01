using Submerge.Utilities;

namespace Submerge.Network;

public class NetworkLayerManager
{
    public static List<NetworkLayer> NetworkLayers = new();
    public static NetworkLayer CurrentLayer { get; set; }
    
    // TODO: Add a proper way to load other layers (Maybe add modular options in settings?)
    public static string DefaultTitle = "Steam"; 

    public static void InitializeLayers()
    {
        NetworkLayers = AssemblyLoader.LoadTypesFromAssembly<NetworkLayer>(Core.SubmergeAssembly);

        foreach (var layer in NetworkLayers)
        {
            if (layer.Title == DefaultTitle)
                CurrentLayer = layer;
        }
    }
}