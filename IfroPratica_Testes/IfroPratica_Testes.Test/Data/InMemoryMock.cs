using IfroPratica_Testes.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroPratica_Testes.Test.Data
{
    public class InMemoryMock
    {
        public static async Task CreateCharacters(InmemoryContext application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                using (var dbContext = provider.GetRequiredService<DataContext>())
                {
                    await dbContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await dbContext.RpgCharacters.AddAsync(new Models.RpgCharacter { Name = "Marlon", RpgClass = "Warlock", HitPoints = 10 });
                        await dbContext.RpgCharacters.AddAsync(new Models.RpgCharacter { Name = "Lorena", RpgClass = "Wizard", HitPoints = 15 });

                        await dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
