using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Concrete
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        MyDbContext _db;
        public CommentRepository(MyDbContext db) : base(db)
        {
            _db = db;   
        }

        public List<Comment> CommentList()
        {
           return _db.Comments.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Product).OrderByDescending(X=>X.ID).ToList();
        }
        public void CommentUpdate(int id, bool check)
        {
           Comment comment= GetById(id);
           comment.Status = DataStatus.Updates;
           comment.ModifiedDate = DateTime.Now;
           comment.IsCheck = check;
           _db.Update(comment);
           _db.SaveChanges();
        }
        public void CommentDelete(int id)
        {
            Delete(id);
        }

        public List<Comment> ProductComments(int productID)
        {
            return _db.Comments.Where(x => x.Status != DataStatus.Deleted && x.ProductID==productID).OrderByDescending(X => X.ID).ToList();
        }
        public List<Comment> ProductCommentsAsc(int productID)
        {
            return _db.Comments.Where(x => x.Status != DataStatus.Deleted && x.ProductID == productID).ToList();
        }
    }
}
