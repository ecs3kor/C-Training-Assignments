using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoschCustomersController : ControllerBase
    {
        private readonly List<Customer> _customers;
        public BoschCustomersController()
        {
            _customers = new List<Customer>()
           {
               new (){CustomerId=1000,ContactName="Alish",City="Bengaluru" },
               new (){CustomerId=1001,ContactName="Aish",City="Mumbai" },
               new (){CustomerId=1002,ContactName="Alishaaa",City="Delhi" }

           };
        }
        /*[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult GetCustomers()
        {
            if (_customers.Count > 0)
            {
                return Ok(_customers);
            }
            else
            {
                return NotFound(new { ErrorMessage = "We did not find any customers.Please try after some time" });
            }
        }*/

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            if (_customers.Count > 0)
            {
                return Ok(_customers);
            }
            else
            {
                return NotFound(new { ErrorMessage = "We did not find any customers.Please try after some time" });
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Customer> Get(int id)
        {
            var customer= _customers.Find(c => c.CustomerId == id);
            if(customer == null)
            {
                return NotFound(new {ErrorMessage = "Customer Not found"});
            }
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customers.Add(customer);
                return CreatedAtAction("GetCustomers", new {id=customer.CustomerId},customer);
            }
            return BadRequest();
        }


        

    }
}
