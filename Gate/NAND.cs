using System.Runtime.CompilerServices;

public static class Gate
{
    // this isn't exactly how cpu nands work, but it is a nand, think about this more like a hobbyist nand
    //  real nands have to worry about constant current and voltage regulation (and voltage direction)
    public static WireBase BuildNAND(WireBase input1, WireBase input2)
    {
        var power = new StraightWire();
        
        var pmos1 = new PMOSTransistor() << input1;
        var pmos2 = new PMOSTransistor() << input2;

        var pmosSerial = power > (pmos1 + pmos2);

        var pmosPath = pmosSerial > new StraightWire();

        var nmos1 = new NMOSTransistor() << input1;
        var nmos2 = new NMOSTransistor() << input2;

        var nmosPath = power > nmos1;

        power.SetVoltage(true);
 
        return pmosPath;
    }
}
