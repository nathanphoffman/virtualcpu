public static class Adder {
    
    public static ValueTuple<WireBase, WireBase> HalfAdder(WireBase a, WireBase b)
    {
        WireBase N1 = Gate.BuildNAND(a, b);
        WireBase N2 = Gate.BuildNAND(a, N1);
        WireBase N3 = Gate.BuildNAND(b, N1);

        WireBase sum = Gate.BuildNAND(N2, N3);
        WireBase carry = Gate.BuildNAND(N1, N1);

        return (sum, carry);

    }

}