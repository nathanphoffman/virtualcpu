using System.Runtime.CompilerServices;

public static class Gate
{
    // CMOS-style NAND: PMOS parallel pull-up, NMOS series pull-down
    public static WireBase BuildNAND(WireBase input1, WireBase input2)
    {
        var power  = new StraightWire();
        var ground = new StraightWire();
        var output = new StraightWire();

        var pmos1 = new PMOSTransistor() << input1;
        var pmos2 = new PMOSTransistor() << input2;
        var pmosPath = power > (pmos1 + pmos2);
        _ = pmosPath > output;

        // nmos isn't actually needed in a theoretical non-electric world as it pulls voltage off pmos to prevent floating
        //  voltages.  In this simulation we use null for floating voltages, but could just as easily treat it as false
        //   in the real world however, that is not possible, so we include here for completeness sake
        var nmos1 = new NMOSTransistor() << input1;
        var nmos2 = new NMOSTransistor() << input2;
        var nmosPath = ground > nmos1 > nmos2;
        _ = nmosPath > output;

        power.SetVoltage(true);
        ground.SetVoltage(false);

        return output;
    }
}
