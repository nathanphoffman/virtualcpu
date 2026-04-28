public class PMOSTransistor : NMOSTransistor
{
    public override void VoltageChange(WireBase source, bool voltage)
    {
        if (Gate == null) throw new Exception("Gate must be set on a transistor");

        bool drainVoltage = !Gate.DrainVoltage ? voltage : false;

        if (drainVoltage != this.DrainVoltage)
            this.sendVoltageToDrain(drainVoltage);
    }
}