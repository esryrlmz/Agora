using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult TakeTransfer()
        {
            return View();
        }
        public IActionResult GiveTransfer()
        {
            return View();
        }
        public IActionResult NewTransfer()
        {
            return View();
        }
    }
}
