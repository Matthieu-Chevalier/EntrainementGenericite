using EntityModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    public class GenericRepository<TEntity> : GenericReadOnlyRepository<TEntity>, IGenericRepository<TEntity> where TEntity : AbstractEntity
    {
        public GenericRepository(DbContext dbContext) : base(dbContext)
        {
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
    }
}
