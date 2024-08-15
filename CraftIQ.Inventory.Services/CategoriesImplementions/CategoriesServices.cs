using CraftIQ.Inventory.Core.Entities;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contract.Categories;
using huzcodes.Persistence.Interfaces.Repositories;

namespace CraftIQ.Inventory.Services.CategoriesImplementions
{
    public class CategoriesServices(IRepository<Category> _repository) : ICategoriesServices
    {
        private readonly IRepository<Category> _repository = _repository;
        public async ValueTask<CategoriesOperationContract> Create(CategoriesOperationContract contract)
        {
        
            var oData = new Category(contract!.Name,
                                     contract.Description);
            var oResult = await _repository.AddAsync(oData);

            return new CategoriesOperationContract(oResult.Name,
                                                    oResult.Description) as dynamic;
        }

        public  ValueTask Delete(Guid contractId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<CategoriesContract>> Read()
        {
            throw new NotImplementedException();
        }

        public ValueTask<CategoriesContract> ReadById(Guid contractId)
        {
            throw new NotImplementedException();
        }

        public ValueTask Update(Guid contractId, CategoriesOperationContract contract)
        {
            throw new NotImplementedException();
        }
    }
}
