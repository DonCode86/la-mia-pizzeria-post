using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            using (PizzaContext context = new PizzaContext())
            {
                IQueryable<Pizza> pizzas = context.Pizzas;

                return View("Index", pizzas.ToList());  
            }
        }

        public IActionResult Details(int id)
        { 
            using (PizzaContext context = new PizzaContext())
            {
                Pizza pizzaFound = context.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaFound == null)
                {
                    return NotFound($"La pizza con id {id} non è stato trovata");
                }
                else
                {
                    return View("Details", pizzaFound);
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formData)
        {
            PizzaContext db = new PizzaContext();

            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }
            
            using (PizzaContext context = new PizzaContext())
            {
                db.Pizzas.Add(formData);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}