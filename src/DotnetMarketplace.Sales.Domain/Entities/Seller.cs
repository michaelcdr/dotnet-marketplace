using MKT.Core.DomainObjects;

namespace DotnetMarketplace.Sales.Domain.Entities
{
    public class Seller : Entity, IAggregateRoot
    {
        protected Seller() 
        {
        
        }

        public Seller(int age, DateTime dateOfBirth, string email, 
                      string webSite, string company, string cNPJ, string branchOfActivity, string fantasyName)
        {
            Age = age;
            DateOfBirth = dateOfBirth;
            Email = email;
            WebSite = webSite;
            Company = company;
            CNPJ = cNPJ;
            BranchOfActivity = branchOfActivity;
            FantasyName = fantasyName;
        }

        public int Age { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string? WebSite { get; private set; }
        public string Company { get; private set; } = string.Empty;
        public string CNPJ { get; private set; } = string.Empty;
        public string BranchOfActivity { get; private set; } = string.Empty;
        public string FantasyName { get; private set; } = string.Empty;
    }
}