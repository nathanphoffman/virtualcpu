
Wire wire1 = new Wire();
Wire wire2 = new Wire();
Wire wire3 = new Wire();

_ = wire1 > wire2 > (wire3 << wire2);
wire1.SetVoltage(true);

Console.WriteLine(Utility.GetBinaryOutput([wire1,wire2,wire3]));

Console.WriteLine("Hello, World! {0}");



