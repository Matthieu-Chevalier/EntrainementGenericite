using EntityModel.Models;
using EntityModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : AbstractEntity 
    {
        public readonly GenericRepository<TEntity> _repository;
        public GenericService(GenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression) => _repository.FindAllWhere(expression);
        public IList<TEntity> GetAll() => _repository.GetAll();


        public TEntity GetById(int id) => _repository.GetById(id);
    }
}
