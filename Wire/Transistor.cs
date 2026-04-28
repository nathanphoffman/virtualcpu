public class Transistor : Wire<Transistor>
{
    public WireBase? Gate;

    public override void VoltageChange(WireBase source, bool voltage)
    {
        if (Gate == null) throw new Exception("Gate must be set on a transistor");

        bool drainVoltage = Gate.DrainVoltage && voltage;

        if (drainVoltage != this.DrainVoltage)
            this.sendVoltageToDrain(drainVoltage);
    }

    // gate: transistor << gateWire — gateWire controls transistor
    public static Transistor operator <<(Transistor transistor, WireBase gate)
    {
        transistor.Gate = gate;

        // this is needed as the gate technically feeds the transistor, 
        //  so voltages coming in on that line need track downstream lines
        gate.ParallelConnectionsNextInSerial = [transistor];

        return transistor;
    }

    // required pair for <<
    public static Transistor operator >>(Transistor transistor, int _)
    {
        throw new NotImplementedException(">> is not supported, use <<");
    }
}
