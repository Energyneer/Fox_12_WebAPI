using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        protected readonly DbSet<T> entities;

        public DataRepository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.ID == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
