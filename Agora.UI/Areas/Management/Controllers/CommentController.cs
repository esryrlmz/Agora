using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class CommentController : Controller
    {
        public IActionResult LastComments()
        {
            List<Comment> comments = new List<Comment>();
            return View(comments);
        }
    }
}
