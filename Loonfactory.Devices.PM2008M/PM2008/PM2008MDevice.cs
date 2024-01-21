using System.Device.I2c;

namespace Loonfactory.Devices.PM2008;

public class PM2008MDevice
{
    public I2cConnectionSettings I2cSetting { get; set; }

    public PM2008MDevice() : this(1, 0x28) { }

    public PM2008MDevice(int busId) : this(busId, 0x28) { }


    public PM2008MDevice(int busId, int deviceAddress) : this(new I2cConnectionSettings(busId, deviceAddress)) { }

    public PM2008MDevice(I2cConnectionSettings i2CConnectionSettings)
    {
        I2cSetting = i2CConnectionSettings;
    }


    public void Start()
    {
        Start(PM2008MI2CCommand.ContinuouslyMeasurementSetup, 0xFFFF);
    }

    public void Start(PM2008MI2CCommand command, ushort data)
    {
        var packet = new PM2008MI2CWritePacket(command, data);
        var writeBuffer = packet.ToBytes();

        using I2cDevice pm2008m = I2cDevice.Create(I2cSetting);
        pm2008m.Write(writeBuffer);
    }

    public PM2008MI2CReadPacket Measure()
    {
        var buffer = new byte[32];
        using (I2cDevice pm2008m = I2cDevice.Create(I2cSetting))
        {
            pm2008m.Read(buffer);
        }

        return new PM2008MI2CReadPacket(buffer);
    }
}
