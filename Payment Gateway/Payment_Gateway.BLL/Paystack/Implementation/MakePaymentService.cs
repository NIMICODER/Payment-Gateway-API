using Microsoft.Extensions.Configuration;
using Payment_Gateway.DAL.Interfaces;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment_Gateway.BLL.Paystack.Interfaces;
using Payment_Gateway.Shared.DataTransferObjects.Request;
using Payment_Gateway.Models.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Payment_Gateway.Shared.DataTransferObjects.Response;

namespace Payment_Gateway.BLL.Paystack.Implementation
{
    public class MakePaymentService : IMakePaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Transaction> _transRepo;
        static IConfiguration _configuration;
        IMapper _mapper;
        public MakePaymentService(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _transRepo = _unitOfWork.GetRepository<Transaction>();
        }

        //public TransactionInitializeResponse ProcessPayment(ProcessPaymentRequest paymentRequest)
        //{
        //    string ApiKey = (string)_configuration.GetSection("Paystack").GetSection("ApiKey").Value;
        //    PayStackApi payStack = new(secretKey: ApiKey);
        //    TransactionInitializeRequest transactionInitializeRequest = _mapper.Map<TransactionInitializeRequest>(paymentRequest);
        //    var result = payStack.Transactions.Initialize(transactionInitializeRequest);
        //    return result;
        //}

        public Task<bool> VerifyPayment()
        {
            throw new NotImplementedException();
        }

        public async Task<object>  ProcessPayment(ProcessPaymentRequest paymentRequest)
        {
            string ApiKey = (string)_configuration.GetSection("Paystack").GetSection("ApiKey").Value;
            string Url = (string)_configuration.GetSection("Paystack").GetSection("Url").Value;
            var payload = new
            {
                email = paymentRequest.Email,
                amount = paymentRequest.AmountInKobo,
                card = new
                {
                    number = paymentRequest.cardNumber,
                    cvv = paymentRequest.cvv,
                    expiry_month = paymentRequest.expiryMonth,
                    expiry_year = paymentRequest.expiryYear
                }
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            var jasonContent = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jasonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Url, httpContent);
            string responseContent = await response.Content.ReadAsStringAsync();
            string reference = JsonConvert.DeserializeObject<dynamic>(responseContent).data.reference;
            string amount = JsonConvert.DeserializeObject<dynamic>(responseContent).data.amount;

            // create Transaction entity
            var transaction = new Transaction
            {
                TrxRef = reference,
                Amount = paymentRequest.AmountInKobo,
                Email = paymentRequest.Email,
                CreatedAt = DateTime.Now
            };
            // add Transaction entity to repository
            _transRepo.Add(transaction);
            // save changes to database
            await _unitOfWork.SaveChangesAsync();


            return new PaymentResponse { Reference = reference, Amount = amount };
        }
    }
}
