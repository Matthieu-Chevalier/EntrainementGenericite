using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : AbstractEntity
    {
        public void Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
    }
}
