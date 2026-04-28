
StraightWire wire1 = new StraightWire();
StraightWire wire2 = new StraightWire();
StraightWire wire3 = new StraightWire();
StraightWire wire4 = new StraightWire();
StraightWire wire5 = new StraightWire();

Transistor transistor = new Transistor();


// > (wire3 << wire2)
var t = wire1 > wire2 > (transistor << wire3) > wire4 > wire5;
wire1.SetVoltage(true);
//wire3.SetVoltage(false);

Console.WriteLine(Utility.GetBinaryOutput([wire1,wire2,wire3,wire4,wire5]));

Console.WriteLine("Hello, World! {0}");



