﻿using EntityModel.Models;
using EntityModel.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Services
{
    public class GenericReadonlyService<TRepository, TEntity> : IGenericReadonlyService<TEntity> where TEntity : AbstractEntity where TRepository : GenericReadOnlyRepository<TEntity>
    {
        public readonly TRepository _repository;

        public GenericReadonlyService(TRepository repository)
        {
            _repository = repository;
        }

        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression) => _repository.FindAllWhere(expression);
        public IList<TEntity> GetAll() => _repository.GetAll();
       

        public TEntity GetById(int id) => _repository.GetById(id);
       
    }
}
