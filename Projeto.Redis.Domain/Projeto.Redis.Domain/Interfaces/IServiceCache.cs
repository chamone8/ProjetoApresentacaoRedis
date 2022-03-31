using Projeto.Redis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Redis.Domain.Interfaces
{
    public interface IServiceCache
    {
        List<Cliente> GetAll();
        Guid Add(Cliente entity);
        Task Update(Guid id, Cliente entity);
        void Delete(Guid id);
        Cliente Get(Guid id);
        void AtualizarCache();
        void LimparCache();
    }
}
