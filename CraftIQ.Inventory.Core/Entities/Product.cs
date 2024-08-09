namespace CraftIQ.Inventory.Core.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; } 
        public float Width { get; set; } 
        public float Height { get; set; } 

        public Guid CategoryId { get; set; }
        public List<Category> Categories { get; set; } = new();
        public decimal TextCost { get; set; }
        public decimal ProfitPerUnit { get; set;}
        public decimal ProductionCost { get; set; }
    }
}
