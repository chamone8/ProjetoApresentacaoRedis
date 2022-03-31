using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Projeto.Redis.Domain.Entities;
using Projeto.Redis.Domain.Interfaces;
using Projeto.Redis.Service.Services;
using Projeto.Redis.Service.Validators;
using System;

namespace Projeto.Redis.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IBaseService<Cliente> _baseUserService;
        private readonly IServiceCache _serviceCache;

        public ClienteController(IBaseService<Cliente> baseUserService, IDistributedCache distributedCache, IServiceCache serviceCache)
        {
            _baseUserService = baseUserService;
            _serviceCache = serviceCache;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return NotFound();


            var clienteCadastro  = _baseUserService.Add<ClienteValidator>(cliente);
            
            _serviceCache.Add(clienteCadastro);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<ClienteValidator>(cliente).Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try {
                if (id == Guid.Empty)
                    return NotFound();

                _baseUserService.Delete(id);

                return Ok();
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _serviceCache.GetAll();

            return Ok(result);
        }
        [HttpGet("GetNoBanco")]
        public IActionResult GetAllBanco()
        {
            var result = _baseUserService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Execute(() => _baseUserService.GetById(id));
        }

        [HttpGet("AtualizarCache")]
        public IActionResult AtualizarCache()
        {
            _serviceCache.AtualizarCache();

            return Ok();
        }

        [HttpGet("LimparCache")]
        public IActionResult LimparCache()
        {
            _serviceCache.LimparCache();

            return Ok();
        }
        private IActionResult Execute(Func<object> func)
        {
            try {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}