using CraftIQ.Inventory.Core.Entities;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.Inventory.API.Endpoints.Categories
{
    public class Category(IRepository<Core.Entities.Category> repository) : EndpointsAsync.WithRequest<CreateCategoryRequest>
                                                .WithActionResult<CreateCategoryResponse>

    {
        private readonly IRepository<Core.Entities.Category> _repository = repository;

        [HttpPost(Routes.CategoriesRoutes.Create)]
        public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync
            (CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("Request can't be null", StatusCodes.Status400BadRequest);

            var oData = new Core.Entities.Category(request.Name, request.Description);
            var oResult = await _repository.AddAsync(oData);
            return Ok(new CreateCategoryResponse(oResult.Name, oResult.Description));
        }

    
    }
}
