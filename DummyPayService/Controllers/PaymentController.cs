using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using DummyPayService.DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace DummyPayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController()
        {

        }

        [HttpPost]
        [Route("create")]
        public ActionResult<string> CreatePayment([FromBody][Required] CreatePaymentRequestParameter parameters)
        {
            return StatusCode((int)HttpStatusCode.OK, parameters);
        }
        
        [HttpPost]
        [Route("confirm")]
        public ActionResult<string> ConfirmPayment([FromBody][Required] ConfirmPaymentRequestParameter parameters)
        {
            return StatusCode((int)HttpStatusCode.OK, parameters);
        }

        [HttpGet]
        [Route("{transactionId}/status")]
        public ActionResult<string> GetPaymentStatus([FromRoute][Required] Guid transactionId)
        {
            return StatusCode((int)HttpStatusCode.OK, transactionId);
        }

    }
}
