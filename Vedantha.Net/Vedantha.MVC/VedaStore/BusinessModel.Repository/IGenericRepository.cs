using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Repository
{
    interface IGenericRepository<T> where T:class
    {
        void Create(T obj);
        T Read(object id);
        IList<T> Find(Expression<Func<T,bool>> creteria);
        void Update(T obj);
        void Delete(object id);
    }
}
