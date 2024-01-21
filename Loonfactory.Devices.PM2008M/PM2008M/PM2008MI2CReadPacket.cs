namespace Loonfactory.Device.PM2008M;

public class PM2008MI2CReadPacket
{
    private static byte CalcCrc(byte[] data, int startIndex, int count)
    {
        var crc = data[startIndex];
        for (int i = startIndex + 1; i < startIndex + count; i++)
        {
            crc ^= data[i];
        }

        return crc;
    }

    public PM2008MI2CReadPacket(byte[] data)
    {
        Data = data;
    }

    static short ToInt16(byte[] value, int startIndex)
    {
        if (!BitConverter.IsLittleEndian)
        {
            return BitConverter.ToInt16(value, startIndex);
        }

        return (short)((value[startIndex] << 8) | value[startIndex + 1]);
    }

    public byte[] Data { get; }

    public byte FrameHeader => Data[0];

    public byte FrameLength => Data[1];

    public byte Status => Data[2];

    public short MeasuringMode => ToInt16(Data, 3);

    public float CalibrationCoefficient => ToInt16(Data, 5) / 10.0f;

    public short GrimmPm1_0 => ToInt16(Data, 7);

    public short GrimmPm2_5 => ToInt16(Data, 9);

    public short GrimmPm10_0 => ToInt16(Data, 11);

    public short TsiPm1_0 => ToInt16(Data, 13);

    public short TsiPM2_5 => ToInt16(Data, 15);

    public short TsiPm10_0 => ToInt16(Data, 17);

    public short Um0_3 => ToInt16(Data, 19);

    public short Um0_5 => ToInt16(Data, 21);

    public short Um1_0 => ToInt16(Data, 23);

    public short Um2_5 => ToInt16(Data, 25);

    public short Um5_0 => ToInt16(Data, 27);

    public short Um10_0 => ToInt16(Data, 29);

    public byte Crc => Data[31];

    public void ThrowIfInvalidCrc()
    {
        var calcedCrc = CalcCrc(Data, 0, 31);
        if (calcedCrc != Crc)
            throw new Exception("Crc error");
    }
}
