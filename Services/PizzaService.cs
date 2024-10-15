using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    static public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1 , Name = "Classic Italian", IsGlutenFree= false},
                new Pizza { Id =  2 , Name = "Veggie" , IsGlutenFree = true}
            };

        }
        //This method is used for get all pizzas in pizza list
        public static List<Pizza> GetAll() => Pizzas;

        //this method that retrieves a specific pizza from the Pizzas list by its ID
        public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        //this method is used for ADD Pizza 
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        // this method is used for update pizza
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }

        //this method is used for delete pizza 
        public static void Delete(int id)
        { 
            var pizza = Get(id);
            if (pizza is null) 
            {
                return;
            }

            Pizzas.Remove(pizza);
        }

    }
}
