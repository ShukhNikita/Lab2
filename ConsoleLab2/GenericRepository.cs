using ConsoleLab2.Interface;
using ConsoleLab2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ProductContext _context;

        private DbSet<T> table;

        public GenericRepository()
        {
            this._context = new ProductContext();
            this.table = _context.Set<T>();
        }

        public void Create(T item)
        {
            table.Add(item);
        }

        public void DeleteByTitem(IEnumerable<T> item)
        {
            table.RemoveRange(item);
        }


        public void DeleteById(int id)
        {
            T item = table.Find(id);
            if (item != null)
            {
                table.Remove(item);
            }

        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            if (table.Count() == 0)
            {
                Console.WriteLine("0");
            }
            return table.ToList();
        }

        public T GetById(int id)
        {
            return this.table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }


    }
}
