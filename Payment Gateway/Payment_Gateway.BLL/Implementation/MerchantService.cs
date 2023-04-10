using Microsoft.AspNetCore.Identity;
using Payment_Gateway.BLL.Interfaces;
using Payment_Gateway.BLL.Interfaces.IServices;
using Payment_Gateway.BLL.LoggerService.Implementation;
using Payment_Gateway.DAL.Interfaces;
using Payment_Gateway.Models.Entities;
using Payment_Gateway.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Gateway.BLL.Implementation
{
    public class MerchantService : IMerchantService
    {
        private readonly IRepository<Merchant> _merchantRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IUserServices _userServices;
        private readonly UserManager<User> _userManager;

        public MerchantService(ILoggerManager logger, IUnitOfWork unitOfWork, UserManager<User> userManager, IUserServices userServices)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userServices = userServices;
            _merchantRepo = _unitOfWork.GetRepository<Merchant>();
        }

        public async Task<string> RegisterMerchant(MerchantForRegistrationDto merchantForRegistratrationDto)
        {
            _logger.LogInfo("Creating the Buyer as a user first, before assigning the buyer role to them and them add them to Buyers table.");

            var user = await _userServices.RegisterUser(new UserForRegistrationDto
            {
                FirstName = merchantForRegistratrationDto.FirstName,
                LastName = merchantForRegistratrationDto.LastName,
                Email = merchantForRegistratrationDto.Email,
                Password = merchantForRegistratrationDto.Password,
                UserName = merchantForRegistratrationDto.UserName
            });

            await _userManager.AddToRoleAsync(user, "Merchant");

            var merchant = new Merchant
            {
                FirstName=merchantForRegistratrationDto.FirstName,
                LastName=merchantForRegistratrationDto.LastName,
                UserName=merchantForRegistratrationDto.UserName,
                PhoneNumber = merchantForRegistratrationDto.PhoneNumber,
                Email = merchantForRegistratrationDto.Email,
                Address = merchantForRegistratrationDto.Address,
                UserId = user.Id

            };

            var result = await _merchantRepo.AddAsync(merchant);

            return $"Registration Successful! You can now start exploring our payment gateway!";
        }
    }
}
