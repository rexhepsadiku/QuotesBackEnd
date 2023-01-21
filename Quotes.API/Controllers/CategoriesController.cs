using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quotes.API.Controllers.Base;
using Quotes.Application.Services.Categories.Commands.Add;
using Quotes.Application.Services.Categories.Commands.Delete;
using Quotes.Application.Services.Categories.Commands.Edit;
using Quotes.Application.Services.Categories.Queries.Get;
using Quotes.Application.Services.Categories.Queries.GetById;

namespace Quotes.API.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new CategoryGetQuery());
            return HandleResult(result);
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new CategoryByIdQuery { Id = id });
            return HandleResult(result);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        /// <summary>
        /// Edit category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Edit(CategoryEditCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new CategoryDeleteCommand { Id = id });
            return HandleResult(result);
        }
    }
}
