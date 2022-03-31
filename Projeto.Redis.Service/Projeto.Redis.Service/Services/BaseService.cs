using FluentValidation;
using Projeto.Redis.Domain.Entities;
using Projeto.Redis.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Projeto.Redis.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(Guid id)
        {
            _baseRepository.Delete(id);
        }
        public IList<TEntity> GetAll()
        {
            return _baseRepository.GetAll();

        }

        public TEntity GetById(Guid id)
        {
            return _baseRepository.GetById(id);

        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}