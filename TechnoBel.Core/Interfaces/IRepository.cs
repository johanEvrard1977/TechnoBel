﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Core.Interfaces
{
    public interface IRepository<TKey, T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetOne(TKey id);
        Task<T> Post(T entity);
        Task<T> Put(TKey id, T entity);
        Task Delete(TKey id);
    }
}
