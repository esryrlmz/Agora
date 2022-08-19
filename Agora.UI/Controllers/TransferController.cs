using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Agora.UI.Controllers
{
    [Authorize(Policy = "UserPolicy")]
    public class TransferController : Controller
    {
        ITransferRepository _repoTransfer;
        IProductRepository _repoProduct;
        IRepository<Cargo> _repoCargo;
        public TransferController(ITransferRepository repoTransfer, IProductRepository repoProduct, IRepository<Cargo> repoCargo)
        {
            _repoProduct=repoProduct;
            _repoTransfer=repoTransfer;
            _repoCargo = repoCargo;
        }
        public IActionResult TakeTransfer()
        {
            var luser = (System.Security.Claims.ClaimsIdentity)User.Identity;
            List<TransferDto> transfers = _repoTransfer.AllTransferList(x => x.UserID == Convert.ToInt32(luser.FindFirst("UserID").Value));
            return View(transfers);
        }
        [Authorize(Policy = "UserPolicy")]
        public IActionResult GiveTransfer()
        {
            var luser = (System.Security.Claims.ClaimsIdentity)User.Identity;
            List<TransferDto> transfers = _repoTransfer.AllTransferList(x => x.Product.User.ID == Convert.ToInt32(luser.FindFirst("UserID").Value));
            return View((transfers, new Cargo()));
        }
        [HttpPost]
        [Authorize(Policy = "UserPolicy")]
        public IActionResult NewTransfer([Bind(Prefix = "Item5")]  TransferDto transfer)
        {
            //is cargo false ise elden, true ise cargo tablosunda alan açmalısın
            // product tablosunda productstatus alanı rezerved olmalı, ıscargo, ıshand alanı guncellenmeli
            // transfer tablosunda productstatus alanı rezerved olmalı
            var luser = (System.Security.Claims.ClaimsIdentity)User.Identity;
            Transfer trnsfr = new Transfer()
            {
                ProductID = transfer.ProductId,
                Adress = transfer.Adress,
                Description = transfer.Description,
                ProductStatus = ProductStatus.Rezerved,
                TransferDate = DateTime.Now,
                UserID= Convert.ToInt32( luser.FindFirst("UserID").Value)
            };
             _repoTransfer.Add(trnsfr);
             var transferid = trnsfr.ID;
             Product prd = _repoProduct.GetById(trnsfr.ProductID);
             prd.ProductStatus = ProductStatus.Rezerved;
             if (transfer.IsCargo) {
                prd.IsCargo = true; prd.IsHandDeliver = false;
                _repoCargo.Add(new Cargo() { TranserID = transferid });
            } else { 
                prd.IsHandDeliver = true; prd.IsCargo = false; 
            }
            _repoProduct.Update(prd);
            return RedirectToAction("TakeTransfer");
        }
        [Authorize(Policy = "UserPolicy")]
        public IActionResult ShowTransfer(int id)
        {
            Transfer transfer = _repoTransfer.GetTransfer(id);
            List<ProductPicture> pictures = _repoProduct.GetProductImages(transfer.ProductID);
            Cargo cargo = _repoTransfer.GetCargo(id);
            return View((transfer, pictures, cargo));
        }






        [Authorize(Policy = "UserPolicy")]
        public IActionResult TransferCancel(int id)
        {
            // kargo ve el transferleri gerçekleşmiş olacagından iptal edilemez silinemez
            // product durumunu yayında olarak güncelle
            Transfer trnsfer = _repoTransfer.GetById(id);
            trnsfer.ProductStatus = MODEL.Enums.ProductStatus.Ownerless;
            _repoTransfer.Update(trnsfer);
            _repoProduct.updateProductStatus(trnsfer.ProductID, MODEL.Enums.ProductStatus.Ownerless);
            // transfer bilgisini kaldır
            _repoTransfer.HardDelete(id);
            return RedirectToAction("TakeTransfer");
        }
        public IActionResult TransferOnay(int id)
        {
            // product durumunu sahiplenildi olarak güncelle
            Transfer trnsfer = _repoTransfer.GetById(id);
            trnsfer.ProductStatus = MODEL.Enums.ProductStatus.Adopted;
            _repoTransfer.Update(trnsfer);
           _repoProduct.updateProductStatus(trnsfer.ProductID, MODEL.Enums.ProductStatus.Adopted);
            return RedirectToAction("GiveTransfer");
        }
        [HttpPost]
        public IActionResult CargoTransferOnay([Bind(Prefix = "Item2")]  Cargo cargo)
        {
            Transfer trnsfer = _repoTransfer.GetById(cargo.TranserID);
            trnsfer.ProductStatus = MODEL.Enums.ProductStatus.Adopted;
            _repoTransfer.Update(trnsfer);

            _repoProduct.updateProductStatus(trnsfer.ProductID, MODEL.Enums.ProductStatus.Adopted);
            Cargo updatecargo = _repoCargo.GetByFilter(x => x.TranserID == cargo.TranserID)[0];
            updatecargo.CargoFirm = cargo.CargoFirm;
            updatecargo.CargoTrackingNumber = cargo.CargoTrackingNumber;
            _repoCargo.Update(updatecargo);
            return RedirectToAction("GiveTransfer");
        }

    }
}
