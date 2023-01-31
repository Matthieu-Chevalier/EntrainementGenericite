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
    public class GenericReadonlyService<TEntity> : IGenericReadonlyService<TEntity> where TEntity : AbstractEntity
    {
        private readonly GenericReadOnlyRepository<TEntity> _repository;
        private readonly DbContext _dbContext;

        public GenericReadonlyService(GenericReadOnlyRepository<TEntity> repository, DbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression) => _repository.FindAllWhere(expression);
        public IList<TEntity> GetAll() => _repository.GetAll();
       

        public TEntity GetById(int id) => _repository.GetById(id);
       
    }
}