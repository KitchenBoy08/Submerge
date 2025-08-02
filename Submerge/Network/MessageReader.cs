namespace Submerge.Network;

public class MessageReader
{
    private byte[] _buffer;
    private uint _readIndex = 0;

    public uint Id { get; private set; }

    public static MessageReader Create(byte[] buffer)
    {
        var reader = new MessageReader
        {
            _buffer = buffer
        };

        // Read message tag
        reader.Id = reader.ReadUInt();
        
        return reader;
    }
    
    public bool ReadBool()
    {
        byte value = _buffer[_readIndex];
        _readIndex++;
        
        return value == 1;
    }

    public byte ReadByte()
    {
        byte value = _buffer[_readIndex];
        _readIndex++;

        return value;
    }
    
    public int ReadInt()
    {
        byte[] bytes = new byte[4];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 4;
        
        return BitConverter.ToInt32(bytes, 0);
    }

    public uint ReadUInt()
    {
        byte[] bytes = new byte[4];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 4;
        
        return BitConverter.ToUInt32(bytes, 0);
    }
    
    public short ReadShort()
    {
        byte[] bytes = new byte[2];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 2;
        
        return BitConverter.ToInt16(bytes, 0);
    }
    
    public ushort ReadUShort()
    {
        byte[] bytes = new byte[2];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 2;
        
        return BitConverter.ToUInt16(bytes, 0);
    }

    public long ReadLong()
    {
        byte[] bytes = new byte[8];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 8;
        
        return BitConverter.ToInt64(bytes, 0);
    }
    
    public ulong ReadULong()
    {
        byte[] bytes = new byte[8];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 8;
        
        return BitConverter.ToUInt64(bytes, 0);
    }

    public float ReadFloat()
    {
        byte[] bytes = new byte[4];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 4;
        
        return BitConverter.ToSingle(bytes, 0);
    }

    public double ReadDouble()
    {
        byte[] bytes = new byte[8];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 8;
        
        return BitConverter.ToDouble(bytes, 0);
    }

    public char ReadChar()
    {
        byte[] bytes = new byte[2];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 2;
        
        return BitConverter.ToChar(bytes, 0);
    }

    public string ReadString()
    {
        var byteCount = ReadInt();
        
        byte[] bytes = new byte[byteCount];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += (uint)byteCount;
        
        return BitConverter.ToString(bytes);
    }

    public DateTime ReadDateTime()
    {
        byte[] bytes = new byte[8];
        _buffer.CopyTo(bytes, _readIndex);
        _readIndex += 8;
        
        var longValue = BitConverter.ToInt64(bytes, 0);
        var value = new DateTime(1980,1,1).AddMilliseconds(longValue);

        return value;
    }
}