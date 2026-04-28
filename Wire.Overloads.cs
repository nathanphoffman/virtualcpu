public partial class Wire
{
    // serial: Wire1 > Wire2 — Wire1 feeds into Wire2
    public static Wire operator >(Wire source, Wire drain)
    {
        source.ParallelConnectionsNextInSerial = [drain];
        return drain;
    }

    // required pair for >
    public static Wire operator <(Wire drain, Wire source)
    {
        source.ParallelConnectionsNextInSerial = [drain];
        return source;
    }

    // fanout: Wire1 > (Wire2 + Wire3) — Wire1 feeds into both Wire2 and Wire3
    public static WireGroup operator >(Wire source, WireGroup drains)
    {
        source.ParallelConnectionsNextInSerial = drains.Wires;
        return drains;
    }

    // required pair for Wire > WireGroup
    public static WireGroup operator <(Wire drain, WireGroup sources)
    {
        return sources;
    }

    // parallel: Wire2 + Wire3 — both receive from the same upstream
    public static WireGroup operator +(Wire a, Wire b)
    {
        return new WireGroup([a, b]);
    }

    // gate: Wire1 << gateWire — gateWire controls Wire1
    public static Wire operator <<(Wire wire, Wire gate)
    {
        return wire.Transistor(gate);
    }

    // required pair for <<
    public static Wire operator >>(Wire wire, int _)
    {
        return wire;
    }
}
