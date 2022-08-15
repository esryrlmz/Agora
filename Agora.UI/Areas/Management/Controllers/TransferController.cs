using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class TransferController : Controller
    {
        ITransferRepository _repoTransfer;
        IProductRepository _repoProduct;
        public TransferController(ITransferRepository repoTransfer, IProductRepository repoProduct)
        {
            _repoTransfer = repoTransfer;
            _repoProduct=repoProduct;
        }
        public IActionResult TransferList()
        {
            List<TransferDto> transfers = _repoTransfer.AllTransferList();
            return View(transfers);
        }
        public IActionResult TransferListCargo()
        {
            List<TransferDto> transfers = _repoTransfer.AllTransferList(x => x.Product.IsCargo == true);
            return View(transfers);
        }
        public IActionResult TransferListHand()
        {
           List < TransferDto > transfers = _repoTransfer.AllTransferList(x => x.Product.IsHandDeliver == true);
            return View(transfers);
        }
       
        public IActionResult ShowTransfer(int id)
        {
            Transfer transfer = _repoTransfer.GetTransfer(id);
            List<ProductPicture> pictures = _repoProduct.GetProductImages(transfer.ProductID);
            Cargo cargo = _repoTransfer.GetCargo(id);
            return View((transfer, pictures, cargo));
        }




        public IActionResult TransferCancel(int id)
        {
            // kargo ve el transferleri gerçekleşmiş olacagından iptal edilemez silinemez
            //product durumunu yayında olarak güncelle
            _repoProduct.updateProductStatus(_repoTransfer.GetById(id).ProductID, MODEL.Enums.ProductStatus.Ownerless);
            // transfer bilgisini kaldır
            _repoTransfer.HardDelete(id);
            return RedirectToAction("TransferList");
        }
    }
}
