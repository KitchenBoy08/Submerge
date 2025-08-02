namespace Submerge.Network;

public abstract class NetworkLayer
{
    public abstract string Title { get; set; }
    
    public abstract bool IsHost { get; }
    public abstract bool IsClient { get; }

    public virtual void Initialize()
    {
        
    }

    public virtual void UpdateLayer()
    {
        
    }

    public abstract void StartServer();
    public abstract void Disconnect();
    public abstract void ConnectToServer(string connectArgs);
    
    public abstract void SendToHost(byte[] data);
    public abstract void SendToClient(byte[] data);
}