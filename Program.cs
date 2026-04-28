static void TestNAND(bool a, bool b)
{
    var inputA = new StraightWire();
    var inputB = new StraightWire();

    inputA.SetVoltage(a);
    inputB.SetVoltage(b);

    var output = Gate.BuildNAND(inputA, inputB);

    Console.WriteLine($"NAND({(a ? 1 : 0)}, {(b ? 1 : 0)}) = {(output.DrainVoltage ? 1 : 0)}");
}

TestNAND(false, false);  // expect 1
TestNAND(false, true);   // expect 1
TestNAND(true, false);  // expect 1
TestNAND(true, true);   // expect 0
