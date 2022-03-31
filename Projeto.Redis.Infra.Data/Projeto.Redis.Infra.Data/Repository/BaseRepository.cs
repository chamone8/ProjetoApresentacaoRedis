using Projeto.Redis.Domain.Entities;
using Projeto.Redis.Domain.Interfaces;
using Projeto.Redis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Redis.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ContextBase _context;

        public BaseRepository(ContextBase context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(Guid id)
        {
            var cliente = _context.Set<TEntity>().Find(id);
            if (cliente != null) {
                _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public IList<TEntity> GetAll()
        {
            try {
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception e) {

                //    throw e;

                return null;
            }
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async void Insert(TEntity obj)
        {
            try {
                obj.Id = Guid.NewGuid();

                _context.Add<TEntity>(obj);
                _context.SaveChanges();

            }
            catch (Exception e) {

                throw e;
            }
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}