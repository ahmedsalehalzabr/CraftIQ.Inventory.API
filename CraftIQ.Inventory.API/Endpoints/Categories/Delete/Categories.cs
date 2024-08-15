using CraftIQ.Inventory.API.Endpoints.Categories.Create;
using CraftIQ.Inventory.Core.Interfaces;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Delete
{
    public class Categories(ICategoriesServices services) : EndpointsAsync
                                                           .WithRequest<CategoriesDeleteRequest>
                                                           .WithActionResult
    {
        private readonly ICategoriesServices services = services;
        [HttpDelete(Routes.CategoriesRoutes.Delete)]
      

        public override async Task<ActionResult> HandleAsync(CategoriesDeleteRequest request, CancellationToken cancellationToken = default)
        {
            await services.Delete(request.categoryId);
            return Ok("your object deleted successfully");
        }
    }
}
