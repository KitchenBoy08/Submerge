using Submerge.Utilities;

namespace Submerge.Network;

public class SteamNetworkLayer : NetworkLayer
{
    public override string Title { get; set; } = "Steam";
    public override bool IsHost { get; }
    public override bool IsClient { get; }

    public override void Initialize()
    {
        Logger.Log("Initialized SteamNetworkLayer");
    }

    public override void StartServer()
    {
    }

    public override void Disconnect()
    {
    }

    public override void ConnectToServer(string connectArgs)
    {
    }

    public override void SendToHost(byte[] data)
    {
    }

    public override void SendToClient(byte[] data)
    {
    }
}