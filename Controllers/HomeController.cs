using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        //handle get methode
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double? firstnum, string operation, double? secondnum)
        {
            // cheking if the numbers have value or not 
            if (!firstnum.HasValue || !secondnum.HasValue)
            {
                ViewBag.Error = "please enter a valid number.";
                return View("Index");
            }
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
            {
               switch (operation)
                {
                    case "+":
                        ViewBag.Result = firstnum.Value + secondnum.Value;
                        break;
                    case "-":
                        ViewBag.Result = firstnum.Value - secondnum.Value;
                        break;
                    case "*":
                        ViewBag.Result = firstnum.Value * secondnum.Value;
                        break;
                    case "/":
                        if (secondnum != 0)
                        {
                            ViewBag.Result = firstnum.Value / secondnum.Value;
                        }
                        else
                        {
                            ViewBag.Result = "Infinity";
                            return View("Index");
                        }
                        break;
                    default:
                        ViewBag.Error = "Enter a valid operation.";
                        return View("Index");
                }
            }
            else
            {
                ViewBag.Result = null;
                ViewBag.Error = "Enter a valid operation.";
            }

            return View("Index");
        }
    }
}
