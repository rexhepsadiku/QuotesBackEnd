using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quotes.API.Controllers.Base;
using Quotes.Application.Services.Quotes.Commands.Add;
using Quotes.Application.Services.Quotes.Commands.Delete;
using Quotes.Application.Services.Quotes.Commands.Edit;
using Quotes.Application.Services.Quotes.Queries.Get;
using Quotes.Application.Services.Quotes.Queries.GetById;
using Quotes.Application.Services.Quotes.Queries.UserQuote;

namespace Quotes.API.Controllers
{
    public class QuotesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all quotes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new QuoteGetQuery());
            return HandleResult(result);    
        }

        /// <summary>
        /// Get quote by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new QuoteByIdQuery { Id = id });
            return HandleResult(result);
        }

        /// <summary>
        /// Add new quote
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(QuoteAddCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        /// <summary>
        /// Edit quote
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Edit(QuoteEditCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        /// <summary>
        /// Delete quote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new QuoteDeleteCommand { Id = id });
            return HandleResult(result);
        }

        /// <summary>
        /// Get user quotes
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("userQuotes")]
        public async Task<IActionResult> UserQuotes()
        {
            var result = await _mediator.Send(new UserQuoteQuery());
            return HandleResult(result);
        }
    }
}
