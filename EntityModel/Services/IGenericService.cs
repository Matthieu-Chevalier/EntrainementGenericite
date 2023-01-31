using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Services
{
    public interface IGenericService<TEntity> where TEntity : AbstractEntity
    {
        public void Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
    }
}
