using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Model;

namespace MyWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICustController : ControllerBase
    {
        private readonly CustomerDBContext _context;

        public APICustController(CustomerDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Customers = _context.Customers.ToList();
                if (Customers == null)
                {
                    return NotFound("Record not available");
                }
                return Ok(Customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Customers = _context.Customers.Find(id);
                if (Customers == null)
                {
                    return NotFound($"Record not available with Id{id}");
                }
                return Ok(Customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPost]
        public IActionResult Post(Customer model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Customer Created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public IActionResult Put(Customer model)
        {
          if(model == null || model.Id ==0)
            {
                return BadRequest("model data is invalid");
            }
          else if(model.Id==0)
            {
                return BadRequest($"customer not found with id {model.Id}");
            }
          try
            {
                var Customer = _context.Customers.Find(model.Id);
                if (Customer == null)
                {
                    return NotFound($"Customer not found with ID{model.Id}");
                }
                Customer.Id = model.Id;
                Customer.Name = model.Name;
                Customer.Description = model.Description;
                _context.SaveChanges();
                return Ok("Customer Details updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]

        public IActionResult Delete(int Id)
        {
            try 
            {
                var Customer = _context.Customers.Find(Id);
                if (Customer == null)
                {
                    return NotFound($"Customer not found with ID{Id}");
                }
                _context.Customers.Remove(Customer);
                _context.SaveChanges();
                return Ok("Customer details deleted");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
     }
}
