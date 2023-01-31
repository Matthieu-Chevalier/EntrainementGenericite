using EntityModel.Models;
using EntityModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Services
{
    public class GenericService<TRepository, TEntity> : GenericReadonlyService<TRepository,TEntity>, IGenericService<TEntity> where TEntity : AbstractEntity where TRepository : GenericRepository<TEntity>
    {
        public GenericService(TRepository repository) : base(repository)
        {
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
    }
}
