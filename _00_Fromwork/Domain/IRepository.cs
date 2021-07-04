﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace _00_Fromwork.Domain
{
    public  interface IRepository<Tkey,T> where  T:class
    {
        T Get(Tkey id);
        List<T> Get();
        void Create(T entity);
        bool Exist(Expression<Func<T, bool>> expression);
        void SaveChanges();

    }
}
