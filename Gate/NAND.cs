public static class Gates
{

    // note because of the way electrical signals work it is more complicated than two transistors to create NAND
    //  here we don't care because it is theoretical and voltage has a binary flow state
    public static WireBase BuildNAND(WireBase input1, WireBase input2)
    {
        var t1 = new Transistor();
        var t2 = new Transistor();
        var nandWire = new StraightWire();
        var outputGate = new StraightWire();

        var primaryGate = (t1 << input1);
        //primaryGate<<(t2 << input2);

        nandWire.ParallelConnectionsNextInSerial = [primaryGate, ];
        return nandWire;
    }
}