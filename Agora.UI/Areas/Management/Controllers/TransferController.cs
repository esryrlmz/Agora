using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class TransferController : Controller
    {
        public IActionResult TransferList()
        {
            List<Transfer> transfers = new List<Transfer>();
            return View(transfers);
        }
        public IActionResult TransferListCargo()
        {
            List<Transfer> transfers = new List<Transfer>();
            return View(transfers);
        }
        public IActionResult TransferListHand()
        {
            List<Transfer> transfers = new List<Transfer>();
            return View(transfers);
        }
        public IActionResult Edit()
        {
            Transfer transfer = new Transfer();
            return View(transfer);
        }
    }
}
