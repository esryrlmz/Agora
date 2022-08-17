using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Concrete
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        MyDbContext _db;
        public TransferRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }

        public List<TransferDto> AllTransferList()
        {
            return _db.Transfers.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted)
                 .Include(x => x.User).Include(x => x.Product).ThenInclude(z => z.User).ThenInclude(z => z.UserDetail)
                 .Select(x => new TransferDto()
                 {
                     TransferID = x.ID,
                     TransferDate = x.TransferDate,
                     ProductTown = x.Product.Town,
                     ProductCity = x.Product.City,
                     Adress = x.Adress,
                     ProductStatus = x.ProductStatus,
                     ProductUserName = x.Product.User.UserDetail.NameSurname,
                     ProductUserId = x.Product.User.ID,
                     TransferUserId = x.User.ID,
                     TransferUserName = x.User.UserDetail.NameSurname,
                     IsCargo = x.Product.IsCargo,
                     IsHandDeliver = x.Product.IsHandDeliver,
                     ProductName=x.Product.ShortName

                 }).OrderByDescending(X => X.TransferID).ToList();
        }
        public List<TransferDto> AllTransferList(Expression<Func<Transfer, bool>> exp)
        {
           return _db.Transfers.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Where(exp)
                .Include(y => y.User).Include(z => z.Product).ThenInclude(t => t.User).ThenInclude(m => m.UserDetail)
                .Select(x => new TransferDto()
                {
                    TransferID=x.ID,
                    TransferDate = x.TransferDate,
                    ProductTown=x.Product.Town,
                    ProductCity=x.Product.City,
                    Adress=x.Adress,
                    ProductStatus=x.ProductStatus,
                    ProductUserName=x.Product.User.UserDetail.NameSurname,
                    ProductUserId=x.Product.User.ID,
                    TransferUserId=x.User.ID,
                    TransferUserName=x.User.UserDetail.NameSurname,
                    IsCargo=x.Product.IsCargo,
                    IsHandDeliver=x.Product.IsHandDeliver,
                    ProductName = x.Product.ShortName

                }).OrderByDescending(X => X.TransferID).ToList();
        }
      
        public Transfer GetTransfer(int id)
        {
           return  _db.Transfers.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted&& x.ID==id)
               .Include(y => y.User).ThenInclude(z => z.UserDetail).Include(t => t.Product).ThenInclude(m => m.User).ThenInclude(k => k.UserDetail)
               .FirstOrDefault();
        }
        public Cargo GetCargo(int TransferId)
        {
            return _db.Cargos.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted&&x.TranserID==TransferId).FirstOrDefault();
        }
    }
}
