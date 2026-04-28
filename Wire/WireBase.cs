public abstract class WireBase
{
    public bool SourceVoltage = false;
    public bool DrainVoltage = false;
    public WireBase[] ParallelConnectionsNextInSerial = [];

    public abstract void VoltageChange(WireBase source, bool voltage);

    public void SetVoltage(bool voltage)
    {
        SourceVoltage = voltage;
        sendVoltageToDrain(voltage);
    }

    protected void sendVoltageToDrain(bool voltage)
    {
        DrainVoltage = voltage;
        foreach (var wire in ParallelConnectionsNextInSerial)
            wire.VoltageChange(this, voltage);
    }
}
