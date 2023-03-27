using IfroPratica_Testes.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace IfroPratica_Testes.Test.Data
{
    public class InmemoryContext : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<DataContext>));

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("TesteDB", root);
                });
            });

            return base.CreateHost(builder);
        }

    }
}
