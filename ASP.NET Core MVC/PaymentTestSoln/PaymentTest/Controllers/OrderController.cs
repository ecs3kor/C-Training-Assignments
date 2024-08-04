using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;

namespace PaymentTest.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InitiatePayment()
        {
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");

            string key = "rzp_test_5uIWEYhHyewMo4";
            string secret = "anIhYfJsmc14R4yZfH2Qp8qk";

            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            ViewBag.orderId = order["id"].ToString();
            return View("Payment");
        }
    }
}
