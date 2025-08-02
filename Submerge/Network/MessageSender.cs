namespace Submerge.Network;

public class MessageSender
{
    public static void SendToHost(MessageWriter writer)
    {
        byte[] data = writer.GetBuffer();
        NetworkLayerManager.CurrentLayer?.SendToHost(data);
    }

    public static void SendToClient(MessageWriter writer)
    {
        byte[] data = writer.GetBuffer();
        NetworkLayerManager.CurrentLayer?.SendToClient(data);
    }

    public static void SendToAll(MessageWriter writer)
    {
        
    }
}