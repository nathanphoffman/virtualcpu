public class NMOSTransistor : Wire<NMOSTransistor>
{
    public WireBase? Gate;
    public WireBase? SourceTerminal;

    public override void VoltageChange(WireBase source)
    {
        if (Gate == null) throw new Exception("Gate must be set on a transistor");

        // If the caller is not the gate, it's the source terminal (ground or upstream transistor).
        // This lets us distinguish "gate fired" from "source voltage changed" without extra wiring.
        if (source != Gate) SourceTerminal = source;

        // Conducting: pass source terminal voltage through (null if source isn't actively driven).
        // Not conducting: null (high-impedance — stop driving, don't actively pull anything).
        bool? drainVoltage = Gate.DrainVoltage == true ? SourceTerminal?.DrainVoltage : null;

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
