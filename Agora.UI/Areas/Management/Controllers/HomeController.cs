using Agora.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class HomeController : Controller
    {
        ITransferRepository _repoTransfer;
        IUserRepository _repoUser;
        IProductRepository _repoProduct;
        ICommentRepository _repoComment;
        public HomeController(ITransferRepository repoTransfer, IUserRepository repoUser, IProductRepository repoProduct, ICommentRepository repoComment)
        {
            _repoTransfer = repoTransfer;
            _repoProduct = repoProduct;
            _repoUser = repoUser;  
            _repoComment = repoComment;
        }
        public IActionResult Index()
        {
            ViewBag.UserCount = _repoProduct.Count();
            ViewBag.TransferCount = _repoTransfer.Count(x=>x.ProductStatus!=MODEL.Enums.ProductStatus.Cancel|| x.ProductStatus != MODEL.Enums.ProductStatus.Rezerved);
            ViewBag.ProductCount = _repoProduct.Count(x => x.ProductStatus == MODEL.Enums.ProductStatus.Ownerless);
            ViewBag.CommentCount = _repoComment.Count();
            return View();
        }
    }
}
