public class PMOSTransistor : NMOSTransistor
{
    public override void VoltageChange(WireBase source)
    {
        if (Gate == null) throw new Exception("Gate must be set on a transistor");

        if (source != Gate) SourceTerminal = source;

        // Conducts when gate is explicitly LOW; null (high-impedance) when gate is HIGH or undriven.
        bool? drainVoltage = Gate.DrainVoltage == false ? SourceTerminal?.DrainVoltage : null;

        if (drainVoltage != this.DrainVoltage)
        {
            DrainVoltage = drainVoltage;
            GatesHaveChanged();
        }
    }
}