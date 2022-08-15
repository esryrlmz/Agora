using Agora.BLL.Interfaces;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class CommentController : Controller
    {
        ICommentRepository _repoComment;
        public CommentController( ICommentRepository repoComment)
        {
            _repoComment = repoComment; 
        }
        public IActionResult LastComments()
        {
            List<Comment> comments = _repoComment.CommentList();
            return View(comments);
        }

        public IActionResult CommentIsActive(int id)
        {
            _repoComment.CommentUpdate(id, true);

            return RedirectToAction("LastComments");
        }
        public IActionResult CommentIsPasive(int id)
        {
            _repoComment.CommentUpdate(id, false);

            return RedirectToAction("LastComments");
        }
        public IActionResult CommentDelete(int id)
        {
            _repoComment.CommentDelete(id);
            return RedirectToAction("LastComments");
        }


    }
}
