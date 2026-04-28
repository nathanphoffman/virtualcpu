
StraightWire wire1 = new StraightWire();
StraightWire wire2 = new StraightWire();
StraightWire wire3 = new StraightWire();
StraightWire wire4 = new StraightWire();

// > (wire3 << wire2)
_ = wire1 > wire2 > wire3 > wire4;
wire1.SetVoltage(true);

Console.WriteLine(Utility.GetBinaryOutput([wire1,wire2,wire3,wire4]));

Console.WriteLine("Hello, World! {0}");



