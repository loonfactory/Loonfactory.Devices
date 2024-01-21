namespace Loonfactory.Devices.PM2008;

public class PM2008MI2CWritePacket
{
    private static byte CalcCrc(byte[] data)
    {
        var crc = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            crc ^= data[i];
        }

        return crc;
    }

    public PM2008MI2CWritePacket(PM2008MI2CCommand command, ushort data)
    {
        Command = command;
        Data = data;
    }

    public byte FrameHeader => 0x16;

    public byte FrameLength => 0x07;

    public PM2008MI2CCommand Command { init; get; }

    public ushort Data { init; get; }

    public byte[] ToBytes()
    {
        var buffer = new byte[7] { FrameHeader, FrameLength, (byte)Command, 0, 0, 0, 0 };
        BitConverter.GetBytes(Data).CopyTo(buffer, 4);
        buffer[^1] = CalcCrc(buffer);
        return buffer;
    }
}
