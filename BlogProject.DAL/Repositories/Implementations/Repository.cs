using BlogProject.Core.Entities.Common;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private DbSet<TEntity> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? orderByExpression = null,
            bool isDescending = false,
            params string[] includes)
        {
            IQueryable<TEntity> query = Table.Where(e => !e.IsDeleted);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (orderByExpression is not null)
            {
                query = isDescending ? query.OrderByDescending(orderByExpression)
               : query.OrderBy(orderByExpression);
            }

            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public async Task Create(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
