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
    public class GenericReadOnlyRepository<TEntity> : IGenericReadOnlyRepository<TEntity> where TEntity : AbstractEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericReadOnlyRepository(DbContext dbContext)
        {
            //TODO : gérer la possibilité d'un context null
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();

            //Désactive le trackage des entités (car lecture seule)
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IList<TEntity> GetAll() => _dbSet.AsNoTracking().ToList();
        public TEntity GetById(int id) => _dbSet.Find(id);

        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        

       
    }
}
