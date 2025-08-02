using Steamworks;
using System.Runtime.InteropServices;

namespace Submerge.Network;

public class SteamConnectionManager : ConnectionManager
{
    public override void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
    {
        base.OnMessage(data, size, messageNum, recvTime, channel);
        
        var managedData = new byte[size];
        Marshal.Copy(data, managedData, 0, size);
        
        Message.HandleMessage(managedData);
    }
}