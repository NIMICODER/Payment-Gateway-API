using Microsoft.AspNetCore.Mvc;
using Payment_Gateway.BLL.Interfaces;
using Payment_Gateway.Shared.DataTransferObjects;

namespace Payment_Gateway.API.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterBuyer([FromBody] MerchantForRegistrationDto merchantForRegistration)
        {

            var response = await _merchantService.RegisterMerchant(merchantForRegistration);

            return Ok(response);
        }
    }
}
