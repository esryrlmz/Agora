using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public interface ITransferRepository:IRepository<Transfer>
    {
        List<TransferDto> AllTransferList();
        public List<TransferDto> AllTransferList(Expression<Func<Transfer, bool>> exp);
        Transfer GetTransfer(int id);
        Cargo GetCargo(int TransferId);


    }
}
