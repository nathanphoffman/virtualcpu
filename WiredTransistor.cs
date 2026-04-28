public class WiredTransistor : Wire
{
    public WiredTransistor(Wire gate)
    {
        this.VoltageChange += (SourceWire upstreamWire, DrainWire[] downstreamWires) =>
        {
            this.SourceVoltage = upstreamWire.DrainVoltage;
            bool drainVoltage = Transistor(gate.DrainVoltage, this.SourceVoltage);
            this.DrainVoltage = drainVoltage;

            if (downstreamWires.Length > 0) updateVoltageOnWires(downstreamWires);
            // !! might add an event here not sure yet
            //else WireTerminated?.Invoke(this.DrainVoltage);
        };
    }

    private static bool Transistor(bool gate, bool source)
    {
        // drain is the downstream line on the transistor, gate opens and closes it, source is incoming voltage
        bool drain = gate && source;
        return drain;
    }
}