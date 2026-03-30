using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Practica5Web3.Controllers
{
    [Authorize(Roles = "Administrador,Farmaceutico")]
    public class FarmaceuticoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}