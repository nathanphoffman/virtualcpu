public class StraightWire : Wire<StraightWire>
{
    public override void VoltageChange(WireBase source)
    {
        // Null means the source stopped driving — don't overwrite what another driver set.
        if (source.DrainVoltage == null) return;
        if (source.DrainVoltage != this.DrainVoltage)
            this.sendVoltageToDrain(source.DrainVoltage);
    }
}
