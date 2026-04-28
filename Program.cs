
StraightWire wire1 = new StraightWire();
StraightWire wire2 = new StraightWire();
StraightWire wire3 = new StraightWire();
StraightWire wire4 = new StraightWire();
StraightWire wire5 = new StraightWire();

StraightWire wire6 = new StraightWire();
StraightWire wire7 = new StraightWire();

var nand = Gate.BuildNAND(wire6,wire7);

NMOSTransistor transistor = new NMOSTransistor();


// > (wire3 << wire2)
var t = wire1 > wire2 > (transistor << wire3) > nand > wire4 > wire5;
wire1.SetVoltage(true);
wire3.SetVoltage(true);

wire6.SetVoltage(true);
wire7.SetVoltage(true);

Console.WriteLine(Utility.GetBinaryOutput([wire1,wire2,wire3,wire4,wire5]));

Console.WriteLine("Hello, World! {0}");



