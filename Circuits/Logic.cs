public class Logic
{
    public static WireBase AND(WireBase a, WireBase b)
    {
        // passing two nands into a nand inverts the signal (as AND is opposite of NAND)
        return Gate.BuildNAND(Gate.BuildNAND(a, b), Gate.BuildNAND(a, b));
    }

    public static WireBase XOR(WireBase a, WireBase b)
    {
        var G1 = Gate.BuildNAND(a, b);

        // what we are doing here is trying to make it so that we have a 0 in each one that disagrees with NAND
        var G2 = Gate.BuildNAND(a, G1);
        var G3 = Gate.BuildNAND(b, G1);

        // now we merge the two positions, the original 1/1 is still 1/1 and so is 0.
        //  the 2 new positions are opposite from one another and so store 1
        //   the original 0/0 was swapped into a 1/1 in both G1 and G2 and so is 0
        var XOR = Gate.BuildNAND(G2,G3);

        return XOR;
    }

}