using DbAccess.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private  readonly BillManagerDbContext _context = null;
        private readonly DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new BillManagerDbContext();
            table = _context.Set<T>();
        }

        public GenericRepository(BillManagerDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetWithPredicate(Func<T, bool> predicate = null)
        {
            if (predicate != null)
                return table.Where(predicate).ToList();
            return table.ToList();
        }


    }
}
