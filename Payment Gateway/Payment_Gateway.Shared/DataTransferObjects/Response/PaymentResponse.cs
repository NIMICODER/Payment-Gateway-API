namespace Payment_Gateway.Shared.DataTransferObjects.Response
{
    public class PaymentResponse
    {

        public string Reference { get; set; }
        public string Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
