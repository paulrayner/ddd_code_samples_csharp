namespace Warranty;

// Value object - using 'record' type introduced in C# 9
public sealed record Product(string Name, string SerialNumber, string Make, string Model);
