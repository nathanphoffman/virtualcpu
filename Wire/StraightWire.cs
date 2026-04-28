public class StraightWire : Wire<StraightWire>
{
    public override void VoltageChange(WireBase source)
    {
        if (source.DrainVoltage != this.DrainVoltage)
            this.sendVoltageToDrain(source.DrainVoltage);
    }
}
