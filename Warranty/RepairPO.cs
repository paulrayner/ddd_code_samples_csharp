namespace Warranty;
public sealed record RepairPO()
{
    public List<LineItem> LineItems = new List<LineItem>();
}