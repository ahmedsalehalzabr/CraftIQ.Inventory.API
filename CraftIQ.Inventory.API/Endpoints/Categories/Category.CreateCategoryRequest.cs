namespace CraftIQ.Inventory.API.Endpoints.Categories
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public CreateCategoryRequest(string name , string description)
        {
            Name = name ;
            Description = description;
        }
    }
}
