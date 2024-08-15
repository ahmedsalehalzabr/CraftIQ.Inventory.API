using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contract.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Update
{
    public class Categories(ICategoriesServices services) : EndpointsAsync.WithRequest<UpdateCategoriesRequest>
                                                                          .WithActionResult
    {
        private readonly ICategoriesServices services = services;

        [HttpPut(Routes.CategoriesRoutes.Update)]
        public override async Task<ActionResult> HandleAsync(UpdateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            
            var oData = new CategoriesOperationContract(request.Category.Name, request.Category.Description);
            await services.Update(request.categoryId, oData);
            return Ok("your object has been updated");
        }
    }
}
