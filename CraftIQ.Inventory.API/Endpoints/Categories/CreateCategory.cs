﻿using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories
{
    public class CreateCategory : EndpointsAsync.WithRequest<CreateCategoryRequest>
                                                .WithActionResult<CreateCategoryRequest>

    {
        [HttpPost(Routes.CategoriesRoutes.CreateCategory)]
        public async override Task<ActionResult<CreateCategoryRequest>> HandleAsync
            (CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var oResult = new CreateCategoryResponse(request.Name, request.Description);
            return Ok(oResult);
        }
        

        
        
    }

}
