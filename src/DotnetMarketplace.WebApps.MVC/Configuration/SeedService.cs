using Dapper;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.WebApps.MVC.Configuration
{
    public class SeedService : ISeedService
    {
        private readonly DapperContext _context;

        public SeedService(DapperContext c)
        {
            _context = c;
        } 

        public async Task Execute()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = @"
                insert into categories(id,title,image)values(NEWID(),'Ferramentas','8bb64aa0184f8d6138a262b5926db6ae.jpg');
                insert into categories(id,title,image)values(NEWID(),'Instrumentos musicais','5d3c5b7a93218_gg.jpg');
                insert into categories(id,title,image)values(NEWID(),'Livros', '51d1qVhmAmL.jpg');
                insert into categories(id,title,image)values(NEWID(),'Veículos' ,'teste0.jpg');
                insert into categories(id,title,image)values(NEWID(),'Suplementos' ,'whey-protein.png');";
                
                await connection.ExecuteAsync(sql);
            }
        }
    }
}