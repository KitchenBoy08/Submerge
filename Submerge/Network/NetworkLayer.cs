namespace Submerge.Network;

public abstract class NetworkLayer
{
    public abstract string Title { get; set; }

    public virtual void Initialize()
    {
        
    }

    public virtual void UpdateLayer()
    {
        
    }
    
    public abstract void SendToHost(byte[] data);
    public abstract void SendToClient(byte[] data);
}