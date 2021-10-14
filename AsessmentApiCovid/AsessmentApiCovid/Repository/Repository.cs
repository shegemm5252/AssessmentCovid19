using AsessmentApiCovid.Data;
using AsessmentApiCovid.Data.DBSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _context;

        private DBSet<T> _table;

        public Repository(ApplicationDbContext context, string JsonPath)
        {
            _context = context;

            var namer = typeof(T).Name;

            _table = _context.Set<T>(JsonPath);
        }
        public void Create(T obj)
        {
           _table.Add(obj);
        }

  

        public void Delete(int index)
        {
            _table.RemoveAt(index);
        }

        public IEnumerable<T> FindByConditionAsync(Func<T, bool> expression)
        {
           return _table.Select(x => x).Where(expression);
        }

       

        public List<T> GetAll()
        {
            return _table.ToList();
        }


        public void Update(T obj)
        {
            _table.Remove(obj);
            _table.Add(obj);
        }

       

       
    }
}
