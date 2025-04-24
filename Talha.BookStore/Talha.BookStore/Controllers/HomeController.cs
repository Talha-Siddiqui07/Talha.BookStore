using Microsoft.AspNetCore.Mvc;

namespace Talha.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from Home Controller";
        }
    }
}
