public static class Utility
{
    public static string ToBinaryString(List<byte> bytes)
    {
        return string.Concat(bytes.Select(b => b == 0 ? '0' : '1'));
    }

    public static string GetBinaryOutput(WireBase[] wires)
    {
        List<byte> bytes = wires.ToList().Select((wire) => Convert.ToByte(wire.DrainVoltage)).ToList();
        return ToBinaryString(bytes);
    }
}
