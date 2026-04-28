public static class Gate
{
    public static WireBase BuildNAND(WireBase input1, WireBase input2)
    {
        var power  = new StraightWire();
        var ground = new StraightWire();
        var output = new StraightWire();

        var pmos1 = new PMOSTransistor();
        var pmos2 = new PMOSTransistor();
        var nmos1 = new NMOSTransistor();
        var nmos2 = new NMOSTransistor();

        // << overwrites gate.ParallelConnectionsNextInSerial, so use it once per input
        // then manually append the second transistor
        _ = pmos1 << input1;
        _ = pmos2 << input2;
        nmos1.Gate = input1;
        nmos2.Gate = input2;
        
        input1.ParallelConnectionsNextInSerial = [..input1.ParallelConnectionsNextInSerial, nmos1];
        input2.ParallelConnectionsNextInSerial = [..input2.ParallelConnectionsNextInSerial, nmos2];

        // pull-up: power fans into both PMOS in parallel, both drain to output
        _ = power > (pmos1 + pmos2);
        _ = pmos1 > output;
        _ = pmos2 > output;

        // pull-down: NMOS in series, both must conduct to send signal to output
        _ = ground > nmos1 > nmos2 > output;

        power.SetVoltage(true);
        ground.SetVoltage(false);

        return output;
    }
}
