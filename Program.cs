static WireBase BuildPMOSPath(WireBase input1, WireBase input2)
{
    var power = new StraightWire();
    var pmos1 = new PMOSTransistor() << input1;
    var pmos2 = new PMOSTransistor() << input2;
    var output = new StraightWire();
    _ = power > (pmos1 + pmos2) > output;
    power.SetVoltage(true);
    return output;
}

static WireBase BuildNMOSPath(WireBase input1, WireBase input2)
{
    var power = new StraightWire();
    var nmos1 = new NMOSTransistor() << input1;
    var nmos2 = new NMOSTransistor() << input2;
    _ = power > nmos1 > nmos2;
    power.SetVoltage(true);
    return nmos2;
}

static void TestPath(string name, Func<WireBase, WireBase, WireBase> build, int[] expected)
{
    bool[][] inputs = [[false,false],[false,true],[true,false],[true,true]];
    Console.WriteLine($"--- {name} ---");
    for (int i = 0; i < 4; i++)
    {
        var a = new StraightWire();
        var b = new StraightWire();
        a.SetVoltage(inputs[i][0]);
        b.SetVoltage(inputs[i][1]);
        var output = build(a, b);
        int result = output.DrainVoltage ? 1 : 0;
        string pass = result == expected[i] ? "✓" : "✗";
        Console.WriteLine($"  ({(inputs[i][0]?1:0)},{(inputs[i][1]?1:0)}) = {result}  expected {expected[i]} {pass}");
    }
}

TestPath("PMOS path", BuildPMOSPath, [1, 1, 1, 0]);
TestPath("NMOS path", BuildNMOSPath, [0, 0, 0, 1]);
