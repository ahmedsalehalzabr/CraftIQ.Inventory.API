using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Categories.Specifications
{
    public class ReadCategoriesByIdSpecification : SingleResultSpecification<Category>
    {
        public ReadCategoriesByIdSpecification()
        {
        }

        public ReadCategoriesByIdSpecification(Guid categoryId)
        {
            Query.Where(o => o._CategoryId == categoryId);
        }
    }
}