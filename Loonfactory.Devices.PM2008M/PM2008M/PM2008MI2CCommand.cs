namespace Loonfactory.Device.PM2008M;

public enum PM2008MI2CCommand : byte
{
    MeasurementClose = 1,
    SingleMeasurementOpen = 2,
    ContinuouslyMeasurementSetup = 3,
    TimingMeasurementSetup = 4,
    DynamicMeasurementSetup = 5,
    CalibrationCoefficientMeasurementSetup = 6,
}
