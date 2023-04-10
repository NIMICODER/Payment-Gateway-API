using Payment_Gateway.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Gateway.BLL.Interfaces
{
    public interface IMerchantService
    {
        Task<string> RegisterMerchant(MerchantForRegistrationDto merchantForRegistratrationDto);
    }
}
