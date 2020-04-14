using DummyPayService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DummyPayService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("final")]
        public IActionResult GetBankEmitentData([FromQuery]string md, [FromQuery]string paRes)
        {
            return View(new BankEmitentDataModel { Md = md, PaRes = paRes });
        }

    }
}
