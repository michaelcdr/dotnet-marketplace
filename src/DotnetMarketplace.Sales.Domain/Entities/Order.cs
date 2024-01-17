using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Sales.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public Order(int total, DateTime createdAt, string userId, 
                     string stateId, string cardOwnerName, string expirationDate, string name, 
                     string address, string neighborhood, string cPF, string cEP, string city, string complement)
        {
            Total = total;
            CreatedAt = createdAt;
            UserId = userId;
            StateId = stateId;
            CardOwnerName = cardOwnerName;
            ExpirationDate = expirationDate;
            Name = name;
            Address = address;
            Neighborhood = neighborhood;
            CPF = cPF;
            CEP = cEP;
            City = city;
            Complement = complement;
            Itens = new List<OrderItem>();
        }

        protected Order() { }

        public int Total { get; private set; }
        public DateTime CreatedAt{ get; private set; }
        public string UserId { get; private set; } = string.Empty;
        public string StateId { get; private set; } = string.Empty;
        public string CardOwnerName { get; private set; } = string.Empty;
        public string ExpirationDate { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Neighborhood { get; private set; } = string.Empty;
        public string CPF { get; private set; } = string.Empty;
        public string CEP { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string Complement { get; private set; } = string.Empty;
        public List<OrderItem> Itens { get; private set; } = new List<OrderItem>();
    }

    public class OrderItem : Entity
    {
        public int OrderId { get; private set; }
        public Order? Order { get; set; }
        public int Qtd { get; private set; }
    }
}