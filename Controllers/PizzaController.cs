using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PizzaController : Controller
    {
        public PizzaController()
        {

        }
        // for get all pizzas in pizza list
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // for get single pizza from pizza list
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        { 
            var Pizza = PizzaService.Get(id);
            if (Pizza == null) 
            {
                return NotFound();
            }
            return Pizza;
        }

        // this http method for ADD Pizza
        [HttpPost]
        public IActionResult Create(Pizza pizza) 
        {
            PizzaService.Add(pizza);

            return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
        }

        // This code will update the pizza and return a result
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            var existingPizza = PizzaService.Get(id); 
            if (existingPizza == null) 
            {
                return NotFound();
            }
            pizza.Id = id;
            PizzaService.Update(pizza);
             return NoContent();
        }

        // This code will delete the pizza and return a result
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPizza = PizzaService.Get(id);
            if (existingPizza == null)
            {
                return NotFound();
            }
            PizzaService.Delete(id);
            return NoContent(); 
        }
    }
}
