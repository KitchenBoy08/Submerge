using System.Reflection;
using Submerge.Utilities;

namespace Submerge.Network;

public abstract class Message
{
    internal static Dictionary<uint, Message> Messages = new();
    
    public abstract uint Id { get; }
    
    public abstract MessageWriter CreateMessage(MessageWriter writer);
    protected abstract void HandleMessage(MessageReader reader);

    internal static void HandleMessage(byte[] data)
    {
        var reader = MessageReader.Create(data);
        var message = Messages[reader.Id];
        
        message.HandleMessage(reader);
    }

    public static void LoadMessages(Assembly assembly)
    {
        var messages = AssemblyLoader.LoadTypesFromAssembly<Message>(assembly);

        foreach (var message in messages)
        {
            if (Messages.ContainsKey(message.Id))
            {
                Logger.Error($"Cannot load {message.GetType().Name} as its tag is already loaded.");
                continue;
            }
            
            Messages.Add(message.Id, message);
        }
    }
}