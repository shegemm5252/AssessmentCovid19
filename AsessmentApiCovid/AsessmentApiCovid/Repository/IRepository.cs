using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        
        void Update(T obj);

        void Delete(int index);

    
        void Create(T obj);

        IEnumerable<T> FindByConditionAsync(Func<T, bool> expression);
    }
}
