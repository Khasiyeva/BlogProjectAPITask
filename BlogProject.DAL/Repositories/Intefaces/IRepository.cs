using BlogProject.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Repositories.Intefaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity,new()
    {
        DbSet<TEntity> Table {  get;}
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? orderByExpression = null,
            bool isDescending = false,
            params string[] includes);
        Task<TEntity> GetByIdAsync(int id);
        Task Create(TEntity entity);
        void Update(TEntity entity);

        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
