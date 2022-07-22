using Agora.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetActives();

        void Add(T item);
        T GetById(int id);

        void Update(T item);

        void Delete(int id);

        void HardDelete(int id);

        List<T> GetByFilter(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);
        int Count();

        int Count(Expression<Func<T, bool>> exp);


    }
}
