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
}
