﻿namespace CraftIQ.Inventory.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public Inventory() { }// for entity framework

        public string Name { get; set; } = string.Empty;
        public Guid _InventoryId { get; set; }
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }

        // relation with products
        // One inventory Many products 
        public List<Product> Products { get; set; } = new();
    }
}
