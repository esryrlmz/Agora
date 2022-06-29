using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        MyDbContext _db;
        protected DbSet<T> table;
        public Repository(MyDbContext db)
        {
            _db = db;
            table=db.Set<T>();  
        }
        private void Save()
        {
            _db.SaveChanges();
        }
        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public void Delete(int id)
        {
            T item= table.Find(id);
            item.Status = DataStatus.Deleted;
            item.ModifiedDate=DateTime.Now;
            table.Update(item);
            Save();
        }

        public List<T> GetActives()
        {
           return table.Where(x => x.Status != DataStatus.Deleted).ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(x => x.Status != DataStatus.Deleted).Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void HardDelete(int id)
        {
            T item = table.Find(id);
            table.Remove(item);
            Save();
        }

        public void Update(T item)
        {
            item.Status = DataStatus.Updates;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }

        public void Add(T item)
        {
            table.Add(item);
            Save();
        }


        
    }
}
