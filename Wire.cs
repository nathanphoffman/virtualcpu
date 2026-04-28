using System.Reflection.Metadata;

public partial class Wire
{
    public event Action<SourceWire, DrainWire[]>? VoltageChange;
    public event Action<List<byte>>? WireTerminated;

    protected bool SourceVoltage = false;
    public bool DrainVoltage = false;

    public ParallelWires ParallelConnectionsNextInSerial = [];


    public Wire {
        
    }

    protected void updateVoltageOnWires(Wire[] downstreamWires)
    {
        downstreamWires.ToList().ForEach((wire) =>
        {
            wire.VoltageChange?.Invoke(this, ParallelConnectionsNextInSerial);
        });
    }

    public void SetVoltage(bool voltage)
    {
        this.SourceVoltage = voltage;
        updateVoltageOnWires(ParallelConnectionsNextInSerial);
    }

}

public class WireGroup
{
    public Wire[] Wires;

    public WireGroup(Wire[] wires)
    {
        Wires = wires;
    }

    // chain more parallel wires: (Wire2 + Wire3) + Wire4
    public static WireGroup operator +(WireGroup group, Wire wire)
    {
        return new WireGroup(group.Wires.Append(wire).ToArray());
    }
}