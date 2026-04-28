public class WireGroup
{
    public WireBase[] Wires;

    public WireGroup(WireBase[] wires)
    {
        Wires = wires;
    }

    // chain more parallel wires: (wire2 + wire3) + wire4
    public static WireGroup operator +(WireGroup group, WireBase wire)
    {
        return new WireGroup(group.Wires.Append(wire).ToArray());
    }

    public static WireBase operator >(WireGroup sources, WireBase drain)
    {
        foreach (var wire in sources.Wires)
            wire.ParallelConnectionsNextInSerial = [.. wire.ParallelConnectionsNextInSerial, drain];
        return drain;
    }

    public static WireBase operator <(WireGroup sources, WireBase drain)
    {
        foreach (var wire in sources.Wires)
            wire.ParallelConnectionsNextInSerial = [.. wire.ParallelConnectionsNextInSerial, drain];
        return drain;
    }

}
