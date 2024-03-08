namespace Warranty;

// Value object - using 'record' type introduced in C# 9
public sealed record LineItem(string Type, double Amount, string Description);
