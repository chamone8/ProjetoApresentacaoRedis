using Microsoft.Extensions.Configuration;
using Projeto.Redis.Domain.Interfaces;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto.Redis.Domain.Entities;

namespace Projeto.Redis.Service.Services
{
    public class ServiceCache : IServiceCache
    {
        private IConfiguration _configuration;
        private RedisManagerPool _redisCache;
        private readonly IBaseService<Cliente> _baseService;
        
        private string _conexao { get { return _configuration.GetConnectionString("RedisServe"); } }

        public ServiceCache(IConfiguration configuration, IBaseService<Cliente> baseService )
        {
            _configuration = configuration;
            _redisCache = new RedisManagerPool(_conexao);
            _baseService = baseService;
        }
        
        public Guid Add(Cliente entity)
        {
            using (var client = _redisCache.GetClient()) {
                client.Set<Cliente>(entity.Id.ToString(), entity);
            }
            
            return entity.Id;
        }

        public Task Update(Guid id, Cliente entity)
        {

            using (var client = _redisCache.GetClient()) {
                client.Set<Cliente>(entity.Id.ToString(), entity);
            }
            return Task.CompletedTask;
        }

        Cliente IServiceCache.Get(Guid id)
        {
            Cliente entity;

            using (var client = _redisCache.GetClient()) {
                
                entity = client.Get<Cliente>(id.ToString());
            }
            return entity;
        }
        public void Delete(Guid id)
        {
            _baseService.Delete(id);

            using (var client = _redisCache.GetClient()) {
                client.Remove(id.ToString());
            }
        }
        List<Cliente> IServiceCache.GetAll()
        {
            using (var client = _redisCache.GetClient()) {
                var keys = client.GetAllKeys();

                var list = new List<Cliente>();

                foreach (var key in keys) {
                    list.Add(client.Get<Cliente>(key));
                }
                return list;
            }
        }

        public void AtualizarCache()
        {
            LimparCache();

            using (var client = _redisCache.GetClient()) {

                var Clientes = _baseService.GetAll();

                foreach (var item in Clientes) {

                    client.Set<Cliente>(item.Id.ToString(), item);
                }
            }
        }

        public void LimparCache()
        {
            using (var client = _redisCache.GetClient()) {

                var Clientes = _baseService.GetAll();

                foreach (var item in Clientes) {

                client.Remove(item.Id.ToString());
                }
            }
        }
    }
}