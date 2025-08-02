using System.Reflection;
using Submerge.Utilities;

namespace Submerge.Network;

public abstract class Message
{
    private static Dictionary<uint, Message> _messages = new();
    
    public abstract uint Id { get; }
    
    public abstract MessageWriter CreateMessage(MessageWriter writer);
    protected abstract void HandleMessage(MessageReader reader);

    internal static void HandleMessage(byte[] data)
    {
        var reader = MessageReader.Create(data);
        var message = _messages[reader.Id];
        
        message.HandleMessage(reader);
    }

    public static void LoadMessages(Assembly assembly)
    {
        var messages = AssemblyLoader.LoadTypesFromAssembly<Message>(assembly);

        foreach (var message in messages)
        {
            if (_messages.ContainsKey(message.Id))
            {
                Logger.Error($"Cannot load {message.GetType().Name} as its tag is already loaded.");
                continue;
            }
            
            Logger.DebugLog($"Loaded message: {message.GetType().Name}");
            _messages.Add(message.Id, message);
        }
    }

    internal static void InitializeMessages()
    {
        LoadMessages(Core.SubmergeAssembly);
    }
}