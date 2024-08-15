using CraftIQ.Inventory.Core.Interfaces;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read
{
    public class Categories(ICategoriesServices services) : EndpointsAsync.WithoutRequest
                                                                          .WithActionResult<ReadCategoriesResponse>
    {
        private readonly ICategoriesServices services = services;

        [HttpGet(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<ReadCategoriesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
           
            var oData = await services.Read();
            var oResult = oData.Select(o => new ReadCategoriesResponse(o)).ToList();
                              
            return Ok(oResult);
        }
    }
}
