public abstract partial class Wire<T> where T : Wire<T>, new()
{
    // serial: wire1 > wire2 — wire1 feeds into wire2, returns wire2 for chaining
    public static T operator >(Wire<T> source, Wire<T> drain)
    {
        source.ParallelConnectionsNextInSerial = [.. source.ParallelConnectionsNextInSerial, drain];
        return (T)drain;
    }

    // required pair for >
    public static T operator <(Wire<T> drain, Wire<T> source)
    {
        source.ParallelConnectionsNextInSerial = [.. source.ParallelConnectionsNextInSerial, drain];
        return (T)source;
    }

    // fanout: wire1 > (wire2 + wire3) — wire1 feeds into both
    public static WireGroup operator >(Wire<T> source, WireGroup drains)
    {
        source.ParallelConnectionsNextInSerial = [..source.ParallelConnectionsNextInSerial,..drains.Wires];
        return drains;
    }

    // required pair for Wire > WireGroup
    public static WireGroup operator <(Wire<T> drain, WireGroup sources)
    {
        return sources;
    }

    // parallel: wire2 + wire3 — both receive from the same upstream
    public static WireGroup operator +(Wire<T> a, Wire<T> b)
    {
        return new WireGroup([a, b]);
    }
}
