using Microsoft.AspNetCore.Mvc;
using Projeto.Redis.Domain.Entities;
using Projeto.Redis.Domain.Interfaces;
using Projeto.Redis.Service.Validators;
using System;

namespace Projeto.Redis.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IBaseService<Cliente> _baseUserService;
        public ClienteController(IBaseService<Cliente> baseUserService)
        {
            _baseUserService = baseUserService ?? throw new  ArgumentNullException(nameof(baseUserService));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<ClienteValidator>(cliente).Id);
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
            return Execute(() => _baseUserService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Execute(() => _baseUserService.GetById(id));
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