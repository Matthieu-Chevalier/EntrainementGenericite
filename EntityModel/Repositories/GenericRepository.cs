using EntityModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AbstractEntity
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;
        public GenericRepository(DbContext dbContext) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity toDelete = _dbSet.Find(id);
            if (toDelete !=null)
            {
                _dbSet.Remove(toDelete);
            }
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public IList<TEntity> GetAll() => _dbSet.AsNoTracking().ToList();
        public TEntity GetById(int id) => _dbSet.Find(id);

        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
    }
}
