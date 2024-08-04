using Bosch.eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Razorpay.Api;

namespace Bosch.eCommerce.MVC.UI.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class HomeController : Controller
    {
        private readonly RazorPaySettings _razorpaySettings;

        public HomeController(IOptions<RazorPaySettings> razorpaySettings)
        {
            _razorpaySettings = razorpaySettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateOrder()
        {
            var client = new RazorpayClient(_razorpaySettings.Key, _razorpaySettings.Secret);
            Console.WriteLine(client);

            Dictionary<string, object> options = new Dictionary<string, object>
            {
                { "amount", 50000 }, 
                { "currency", "INR" },
                { "receipt", "order_rcptid_11" }
            };

            Order order = client.Order.Create(options);
            ViewBag.OrderId = order["id"].ToString();
            ViewBag.RazorpayKey = _razorpaySettings.Key;
            ViewBag.Amount = 50000; 
            return View("CreateOrder");
        }

        [HttpPost]
        public IActionResult CompletePayment(string paymentId, string orderId, string signature)
        {
            var client = new RazorpayClient(_razorpaySettings.Key, _razorpaySettings.Secret);

            Dictionary<string, string> attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", paymentId },
                { "razorpay_order_id", orderId },
                { "razorpay_signature", signature }
            };

            return View("PaymentSuccess");

            /*try
            {
                Utils.verifyPaymentSignature(attributes);
                // If no exception is thrown, signature is valid
                return RedirectToAction("PaymentSuccess");
            }
            catch (Exception ex)
            {
                // Handle exception (signature verification failed)
                return RedirectToAction("PaymentFailure");
            }*/
        }

        

        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult PaymentFailure()
        {
            return View();
        }
    }
}
