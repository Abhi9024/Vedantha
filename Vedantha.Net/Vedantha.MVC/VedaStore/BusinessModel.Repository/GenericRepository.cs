using BusinessModel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace BusinessModel.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class 
    {
        readonly pubsContext _pubsContext;
        public GenericRepository(pubsContext pubsContext)
        {
            _pubsContext = pubsContext;
        }


        public void Create(T obj)
        {
            if (_pubsContext.Entry<T>(obj).State == EntityState.Detached)
                _pubsContext.Entry<T>(obj).State = EntityState.Added;
            else
                _pubsContext.Set<T>().Attach(obj);

            _pubsContext.SaveChanges();
        }

        public T Read(object id)
        {
            var entity = _pubsContext.Set<T>().Find(id);
            return entity;
        }

        public IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> creteria)
        {
            return _pubsContext.Set<T>().Where(creteria).ToList();
        }

        public void Update(T obj)
        {
            _pubsContext.Set<T>().Attach(obj);
            _pubsContext.Entry<T>(obj).State = EntityState.Modified;

            _pubsContext.SaveChanges();
        }

        public void Delete(object id)
        {
            _pubsContext.Set<T>().Remove(Read(id));
            _pubsContext.SaveChanges();
        }
    }
}
