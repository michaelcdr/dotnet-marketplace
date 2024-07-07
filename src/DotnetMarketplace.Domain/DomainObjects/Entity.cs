using DotnetMarketplace.Core.Messages;

namespace DotnetMarketplace.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        
        private List<Event>? _notificacoes;
        
        public IReadOnlyCollection<Event>? Notificacoes => _notificacoes?.AsReadOnly();
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}