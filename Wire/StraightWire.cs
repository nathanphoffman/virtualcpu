public class StraightWire : Wire<StraightWire>
{
    public override void VoltageChange(WireBase source, bool voltage)
    {
        if (voltage != this.DrainVoltage)
            this.sendVoltageToDrain(voltage);
    }
}
