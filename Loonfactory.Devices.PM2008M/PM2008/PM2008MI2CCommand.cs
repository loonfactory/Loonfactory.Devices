namespace Loonfactory.Devices.PM2008;

public enum PM2008MI2CCommand : byte
{
    MeasurementClose = 1,
    SingleMeasurementOpen = 2,
    ContinuouslyMeasurementSetup = 3,
    TimingMeasurementSetup = 4,
    DynamicMeasurementSetup = 5,
    CalibrationCoefficientMeasurementSetup = 6,
}
