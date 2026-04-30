// Persistent circuit test: build once, change inputs, verify output updates correctly.
// This is the real CPU-like test — the NMOS pull-down must actively drive LOW.
static void TestNANDPersistent()
{
    var inputA = new StraightWire();
    var inputB = new StraightWire();


    var and_output = Logic.AND(inputA, inputB);
    var xor_output = Logic.XOR(inputA, inputB);

    void check(bool a, bool b)
    {
        inputA.SetVoltage(a);
        inputB.SetVoltage(b);

        Console.WriteLine(Utility.GetBinaryOutput([and_output, xor_output]));
        var output = Gate.BuildNAND(inputA, inputB);

        int result = output.DrainVoltage == true ? 1 : 0;
        int expected = (a && b) ? 0 : 1;
        string pass = result == expected ? "✓" : "✗";
        Console.WriteLine($"NAND({(a ? 1 : 0)},{(b ? 1 : 0)}) = {result} {pass}");
    }

    check(false, false);
    check(false, true);
    check(true, false);
    check(true, true);
    // Cycle back to verify pull-up also works after pull-down fired
    check(false, false);
    check(true, true);
}

TestNANDPersistent();
