namespace CraftIQ.Inventory.Shared.Contract.Categories
{
    public class CategoriesOperationContract
    {
        public Guid _CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // relation with products
        // One category Many products 
     
        public CategoriesOperationContract(string name, string description)
        {
           
            Name = name;
            Description = description;
           
        }
    }
}
