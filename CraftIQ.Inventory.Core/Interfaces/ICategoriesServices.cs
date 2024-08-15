using CraftIQ.Inventory.Shared.Contract.Categories;

namespace CraftIQ.Inventory.Core.Interfaces
{
    public interface ICategoriesServices
    {
        ValueTask<CategoriesOperationContract> Create(CategoriesOperationContract contract);
        ValueTask<List<CategoriesContract>> Read();
      //  ValueTask<List<CategoriesContract>> ReadByParentId(Guid parentContractId);
        ValueTask<CategoriesContract> ReadById(Guid categoryId);
      //  ValueTask<CategoriesContract> ReadSingleByParentId(Guid contractId, Guid parentContractId);
        ValueTask Update(Guid categoryId, CategoriesOperationContract contract);
      //  ValueTask UpdateParentId(Guid contractId, Guid parentContractId);
        ValueTask Delete(Guid categoryId);
    }
}
