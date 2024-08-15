using CraftIQ.Inventory.Shared.Contract.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftIQ.Inventory.Core.Interfaces
{
    public interface ICategoriesServices
    {
        ValueTask<CategoriesOperationContract> Create(CategoriesOperationContract contract);
        ValueTask<List<CategoriesContract>> Read();
      //  ValueTask<List<CategoriesContract>> ReadByParentId(Guid parentContractId);
        ValueTask<CategoriesContract> ReadById(Guid contractId);
      //  ValueTask<CategoriesContract> ReadSingleByParentId(Guid contractId, Guid parentContractId);
        ValueTask Update(Guid contractId, CategoriesOperationContract contract);
      //  ValueTask UpdateParentId(Guid contractId, Guid parentContractId);
        ValueTask Delete(Guid contractId);
    }
}
