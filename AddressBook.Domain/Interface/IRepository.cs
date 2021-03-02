using AddressBookAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.Infrastructure
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T GetLastAdded();
        IEnumerable<T> SearchBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
