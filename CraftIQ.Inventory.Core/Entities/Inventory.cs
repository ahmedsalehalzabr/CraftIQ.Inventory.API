namespace CraftIQ.Inventory.Core.Entities
{
    public class Inventory
    {
        public Inventory() { } // for entity framework
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public List<Product> Products { get; set; } = new();
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }
    }
}
