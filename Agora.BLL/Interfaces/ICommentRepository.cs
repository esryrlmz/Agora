using Agora.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public interface ICommentRepository:IRepository<Comment>
    {
        public List<Comment> CommentList();
        void CommentUpdate(int id, bool check);
        void CommentDelete(int id);
    }
}
