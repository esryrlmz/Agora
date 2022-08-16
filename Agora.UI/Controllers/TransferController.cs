using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    [Authorize(Policy = "UserPolicy")]
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
        public IActionResult NewTransfer(int id)
        {
            //parametre olarak product id geliyor
            return View();
        }
    }
}
