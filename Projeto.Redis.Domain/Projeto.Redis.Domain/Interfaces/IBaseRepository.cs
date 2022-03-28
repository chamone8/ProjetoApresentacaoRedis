using Projeto.Redis.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Projeto.Redis.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(Guid id);
        IList<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}