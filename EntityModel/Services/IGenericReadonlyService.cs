using EntityModel.Models;
using System.Linq.Expressions;

namespace EntityModel.Services
{
    public interface IGenericReadonlyService<TEntity> where TEntity : AbstractEntity
    {
        public TEntity GetById(int id);
        public IList<TEntity> GetAll();
        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression);
    }
}
