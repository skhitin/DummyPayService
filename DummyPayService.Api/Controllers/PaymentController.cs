using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using DummyPayService.Core.Commands;
using DummyPayService.Core.DataContracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DummyPayService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediator { get; }

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePaymentAsync([FromBody][Required] CreatePaymentRequestParameter requestParameter)
        {
            var command = new CreatePaymentCommand(requestParameter);
            var result = await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("confirm")]
        public async Task<ActionResult<string>> ConfirmPaymentAsync([FromBody][Required] ConfirmPaymentRequestParameter requestParameter)
        {
            var command = new ConfirmPaymentCommand(requestParameter);
            var result = await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("{transactionId}/status")]
        public async Task<ActionResult<string>> GetPaymentStatusAsync([FromRoute][Required] Guid transactionId)
        {
            var command = new GetPaymentStatusCommand(transactionId);
            var result = await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, result);
        }

    }
}
