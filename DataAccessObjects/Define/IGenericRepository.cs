﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Define
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        T? GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
