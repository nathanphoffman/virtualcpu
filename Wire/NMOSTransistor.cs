public class NMOSTransistor : Wire<NMOSTransistor>
{
    public WireBase? Gate;

    public override void VoltageChange(WireBase source)
    {
        if (Gate == null) throw new Exception("Gate must be set on a transistor");

        bool drainVoltage = Gate.DrainVoltage;

        if (drainVoltage != this.DrainVoltage)
        {
            DrainVoltage = drainVoltage;
            GatesHaveChanged();
        }
    }

    // gate: transistor << gateWire — gateWire controls transistor
    public static NMOSTransistor operator <<(NMOSTransistor transistor, WireBase gate)
    {
        transistor.Gate = gate;

        // this is needed as the gate technically feeds the transistor, 
        //  so voltages coming in on that line need track downstream lines
        gate.ParallelConnectionsNextInSerial = gate.ParallelConnectionsNextInSerial.Append(transistor).ToArray();

        return transistor;
    }

    // required pair for <<
    public static NMOSTransistor operator >>(NMOSTransistor transistor, int _)
    {
        throw new NotImplementedException(">> is not supported, use <<");
    }

    public void GatesHaveChanged()
    {
        foreach (var wire in ParallelConnectionsNextInSerial)
            wire.VoltageChange(this);
    }
}
