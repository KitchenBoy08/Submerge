namespace Submerge.Network;

public class NetworkHelper
{
    public static bool IsHost => NetworkLayerManager.CurrentLayer?.IsHost ?? false;
    public static bool IsClient => NetworkLayerManager.CurrentLayer?.IsClient ?? false;
    
    public static void StartServer()
    {
        NetworkLayerManager.CurrentLayer?.StartServer();   
    }

    public static void Disconnect()
    {
        NetworkLayerManager.CurrentLayer?.Disconnect();   
    }
    
    public static void ConnectToServer(string connectArgs)
    {
        NetworkLayerManager.CurrentLayer?.ConnectToServer(connectArgs);   
    }
}