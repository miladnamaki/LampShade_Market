using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using _00_Fromwork.Domain;
using Microsoft.EntityFrameworkCore;

namespace _00_Fromwork.Infrastructure
{
    public class RepositoryBase<Tkey, t> : IRepository<Tkey, t> where t : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(t entity)
        {
            _context.Add(entity);
        }

        public bool Exist(Expression<Func<t, bool>> expression)
        {
            return _context.Set<t>().Any(expression);
        }

        public t Get(Tkey id)
        {
            return _context.Find<t>(id);
        }

        public List<t> Get()
        {
            return _context.Set<t>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
