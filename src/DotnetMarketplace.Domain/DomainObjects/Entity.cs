using DotnetMarketplace.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMarketplace.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        
        private List<Event> _notificacoes;
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
