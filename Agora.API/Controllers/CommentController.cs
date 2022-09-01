using Agora.BLL.Interfaces;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Agora.API.Controllers
{
    [Route("api/v1/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        ICommentRepository _repoComment;
        public CommentController(ICommentRepository repoComment)
        {
            _repoComment= repoComment;
        }

        [HttpGet("{product_id:int}")]
        public IEnumerable<Comment> getComments(int product_id)
        {
            return _repoComment.ProductComments(product_id).ToArray() ;
        }

        [HttpDelete("{comment_id:int}")]
        public ActionResult<UserDetail> DeleteComment(int comment_id)
        {
            try
            {
                _repoComment.HardDelete(comment_id);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
