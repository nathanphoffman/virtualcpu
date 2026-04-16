using System.Reflection.Metadata;
using ParallelWires = Wire[];

public class Wire
{
    public ParallelWires[] GroundSerialConnections = [];

    private void ConnectTransistor()
    {
        throw new NotImplementedException();
    }

    private static bool Transistor(bool gate, bool source)
    {
        // drain is the downstream line on the transistor
        bool drain = gate && source;
        return drain;
    }


}