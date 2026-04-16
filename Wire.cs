using System.Reflection.Metadata;
using ParallelWires = Wire[];
using SourceWire = Wire;
using DrainWire = Wire;
using GateWire = Wire;

public class Wire
{
    public event Action<SourceWire, DrainWire[]>? VoltageChange;
    public event Action<List<byte>>? WireTerminated;

    private bool SourceVoltage = false;
    private bool DrainVoltage = false;

    public ParallelWires ParallelConnectionsNextInSerial = [];

    public Wire GetTransistor(GateWire gate)
    {
        this.VoltageChange += (SourceWire upstreamWire, DrainWire[] downstreamWires) =>
        {
            this.SourceVoltage = upstreamWire.DrainVoltage;
            bool drainVoltage = Transistor(gate.DrainVoltage, this.SourceVoltage);
            this.DrainVoltage = drainVoltage;

            if(downstreamWires.Length > 0) updateVoltageOnWires(downstreamWires);
            else WireTerminated?.Invoke();
        };

        return this;
    }

    private void updateVoltageOnWires(Wire[] downstreamWires)
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

    public static List<byte> GetBinaryOutput(Wire[] wires)
    {
        List<byte> bytes = wires.ToList().Select((wire) => Convert.ToByte(wire.DrainVoltage)).ToList();
        return bytes;
    } 

    private static bool Transistor(bool gate, bool source)
    {
        // drain is the downstream line on the transistor, gate opens and closes it, source is incoming voltage
        bool drain = gate && source;
        return drain;
    }


}