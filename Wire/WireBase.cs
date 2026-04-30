public abstract class WireBase
{
    // cross-type chaining fallback (e.g. StraightWire > NMOSTransistor)
    public static WireBase operator >(WireBase source, WireBase drain)
    {
        source.ParallelConnectionsNextInSerial = [.. source.ParallelConnectionsNextInSerial, drain];
        return drain;
    }

    public static WireBase operator <(WireBase drain, WireBase source)
    {
        source.ParallelConnectionsNextInSerial = [.. source.ParallelConnectionsNextInSerial, drain];
        return source;
    }


    public bool SourceVoltage = false;
    // null = high-impedance (not actively driven), true/false = actively driven
    public bool? DrainVoltage = null;
    public WireBase[] ParallelConnectionsNextInSerial = [];

    public abstract void VoltageChange(WireBase source);

    public void SetVoltage(bool voltage)
    {
        SourceVoltage = voltage;
        sendVoltageToDrain(voltage);
    }

    protected void sendVoltageToDrain(bool? voltage)
    {
        DrainVoltage = voltage;
        foreach (var wire in ParallelConnectionsNextInSerial)
            wire.VoltageChange(this);
    }
}
