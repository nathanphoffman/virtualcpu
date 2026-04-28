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
}
