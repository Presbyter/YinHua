using YinHua.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace YinHua.Services
{
    public class BaseService<TEntity> where TEntity : BaseEntity
    {
        private YinHuaContext _db;
        public virtual int Create(params TEntity[] entities)
        {
            int resultCount = 0;
            using (_db = new YinHuaContext())
            {
                foreach (var item in entities)
                {
                    item.CreateTime = DateTime.Now;
                    item.ModifyTime = DateTime.Now;
                    _db.Entry(item).State = EntityState.Added;
                }
                resultCount = _db.SaveChanges();
            }
            return resultCount;
        }

        public virtual int Update(params TEntity[] entities)
        {
            int resultCount = 0;
            using (_db = new YinHuaContext())
            {
                foreach (var item in entities)
                {
                    item.ModifyTime = DateTime.Now;
                    _db.Entry(item).State = EntityState.Modified;
                }
                resultCount = _db.SaveChanges();
            }
            return resultCount;
        }

        public virtual int Remove(params TEntity[] entities)
        {
            int resultCount = 0;
            using (_db = new YinHuaContext())
            {
                foreach (var item in entities)
                {
                    _db.Entry(item).State = EntityState.Deleted;
                }
                resultCount = _db.SaveChanges();
            }
            return resultCount;
        }

        public virtual TEntity GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity result;
            using (_db = new YinHuaContext())
            {
                IQueryable<TEntity> dbQuery = _db.Set<TEntity>();
                foreach (var item in navigationProperties)
                {
                    dbQuery = dbQuery.Include<TEntity, object>(item);
                }
                result = dbQuery.AsNoTracking().FirstOrDefault(where);
            }
            return result;
        }

        public virtual IList<TEntity> GetList(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> result;
            using (_db = new YinHuaContext())
            {
                IQueryable<TEntity> dbQuery = _db.Set<TEntity>();
                foreach (var item in navigationProperties)
                {
                    dbQuery = dbQuery.Include<TEntity, object>(item);
                }
                result = dbQuery.AsNoTracking().Where(where).ToList();
            }
            return result;
        }

        public virtual IList<TEntity> GetAll(params Expression<Func<TEntity, Object>>[] navigationParoperties)
        {
            List<TEntity> result;
            using (_db = new YinHuaContext())
            {
                IQueryable<TEntity> dbQuery = _db.Set<TEntity>();
                foreach (var item in navigationParoperties)
                {
                    dbQuery = dbQuery.Include<TEntity, Object>(item);
                }
                result = dbQuery.AsNoTracking().ToList();
            }
            return result;
        }
    }
}