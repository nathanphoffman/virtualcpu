public class PMOSTransistor : NMOSTransistor
{
    public override void VoltageChange(WireBase source)
    {
        if (Gate == null) throw new Exception("Gate must be set on a transistor");

        bool drainVoltage = !Gate.DrainVoltage ? source.DrainVoltage : false;

        if (drainVoltage != this.DrainVoltage)
        {
            DrainVoltage = drainVoltage;
            GatesHaveChanged();
        }
    }
}