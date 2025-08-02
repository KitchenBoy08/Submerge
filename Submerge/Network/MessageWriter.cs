using System.Text;
using FMOD;
using Submerge.Utilities;

namespace Submerge.Network;

public class MessageWriter
{
    private byte[] _buffer = Array.Empty<byte>();
    
    public byte[] GetBuffer() => _buffer;

    public static MessageWriter Create(Message message)
    {
        if (message == null || message.Id == 0)
        {
            Logger.Error("Cannot create writer since message is invalid!");
            return null;
        }
        
        // Assign message tag
        var writer = new MessageWriter();
        writer.WriteUInt(message.Id);
        
        return writer;
    }

    public void WriteBool(bool value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 1];
        _buffer.CopyTo(newBuffer, 0);
        newBuffer[_buffer.Length] = value ? (byte)1 : (byte)0;
        _buffer = newBuffer;
    }

    public void WriteByte(byte value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 1];
        _buffer.CopyTo(newBuffer, 0);
        newBuffer[_buffer.Length] = value;
        _buffer = newBuffer;
    }
    
    public void WriteInt(int value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 4];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteUInt(uint value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 4];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }
    
    public void WriteShort(short value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 2];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }
    
    public void WriteUShort(ushort value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 2];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteLong(long value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 8];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }
    
    public void WriteULong(ulong value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 8];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteFloat(float value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 4];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteDouble(double value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 8];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteChar(char value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 2];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteString(string value)
    {
        Encoding encoding = Encoding.UTF8;
            
        int byteCount = encoding.GetByteCount(value);
        byte[] stringBytes = encoding.GetBytes(value);
        
        WriteInt(byteCount);
        
        byte[] newBuffer = new byte[_buffer.Length + byteCount];;
        _buffer.CopyTo(newBuffer, 0);
        stringBytes.CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }

    public void WriteDateTime(DateTime value)
    {
        byte[] newBuffer = new byte[_buffer.Length + 8];
        _buffer.CopyTo(newBuffer, 0);
        BitConverter.GetBytes(value.ToBinary()).CopyTo(newBuffer, _buffer.Length);
        _buffer = newBuffer;
    }
}