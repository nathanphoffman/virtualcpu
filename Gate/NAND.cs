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

        var nmos1 = new NMOSTransistor() << input1;
        var nmos2 = new NMOSTransistor() << input2;
        var nmosPath = ground > nmos1 > nmos2;
        _ = nmosPath > output;

        power.SetVoltage(true);
        ground.SetVoltage(false);

        return output;
    }
}
