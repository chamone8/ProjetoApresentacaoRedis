using System;

namespace Projeto.Redis.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}