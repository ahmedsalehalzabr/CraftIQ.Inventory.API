using CraftIQ.Inventory.Core.Entities;
using CraftIQ.Inventory.Core.Entities.Categories.Specifications;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contract.Categories;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Diagnostics.Contracts;
using System.Net;

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

      

        public async ValueTask<List<CategoriesContract>> Read()
        {
            var oReadSpec = new ReadCategoriesSpecification();
            var oData = await _repository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new CategoriesContract(o._CategoryId,
                                                                       o.Name,
                                                                       o.Description,
                                                                       o.CreatedBy,
                                                                       o.ModifiedBy,
                                                                       o.CreatedOn,
                                                                       o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<CategoriesContract>() as dynamic;
        }

        public async ValueTask<CategoriesContract> ReadById(Guid contractId)
        {
            var oReadByIdSpec = new ReadCategoriesByIdSpecification(contractId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                return new CategoriesContract(oResult._CategoryId,
                                              oResult.Name,
                                              oResult.Description,
                                              oResult.CreatedBy,
                                              oResult.ModifiedBy,
                                              oResult.CreatedOn,
                                              oResult.ModifiedOn) as dynamic;

            else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
        }

        public async ValueTask Update(Guid categoryId, CategoriesOperationContract contract)
        {
            var oReadByIdSpec = new ReadCategoriesByIdSpecification(categoryId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
            {
                // oResult.UpdateCategory(oContract!.Name, oContract.Description, Guid.NewGuid());
                await _repository.UpdateAsync(oResult);
            }

            else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
        }
        public async ValueTask Delete(Guid categoryId)
        {
            var oReadByIdSpec = new ReadCategoriesByIdSpecification(categoryId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _repository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete object that is not exit.", (int)HttpStatusCode.Forbidden);
        }
    }
}

//public async ValueTask<int> Delete(Guid categoryId)
//{
//    var oReadByIdSpec = new ReadCategoriesByIdSpecification(categoryId);
//    var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
//    if (oResult != null)
//        await _repository.DeleteAsync(oResult);
//    else throw new ResultException("You can't delete object that is not exit.", (int)HttpStatusCode.Forbidden);
//}


//public async ValueTask Update(Guid categoryId, CategoriesOperationContract contract)
//{
//    var oReadByIdSpec = new ReadCategoriesByIdSpecification(categoryId);
//    var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
//    if (oResult != null)
//    {
//        // oResult.UpdateCategory(oContract!.Name, oContract.Description, Guid.NewGuid());
//        await _repository.UpdateAsync(oResult);
//    }

//    else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
//}
