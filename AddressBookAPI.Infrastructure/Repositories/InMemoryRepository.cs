using AddressBookAPI.Domain.Interface;
using AddressBookAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AddressBookAPI.Infrastructure.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity<Guid>
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApiContext _context;
        public InMemoryRepository(ApiContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public T GetLastAdded()
        {
            var address = _dbSet.ToArray().OrderByDescending(x => x.RecordCreateTime).First();
            return address;
        }

        public IEnumerable<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
    }
}
