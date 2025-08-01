namespace Submerge.Network;

public class SteamNetworkLayer : NetworkLayer
{
    public override string Title { get; set; }
    
    
    public override void SendToHost(byte[] data)
    {
    }

    public override void SendToClient(byte[] data)
    {
    }
}