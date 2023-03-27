using IfroPratica_Testes.Models;
using Microsoft.EntityFrameworkCore;

namespace IfroPratica_Testes.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<RpgCharacter> RpgCharacters => Set<RpgCharacter>();
    }
}
