using IfroPratica_Testes.Controllers;
using IfroPratica_Testes.Data;
using IfroPratica_Testes.Test.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace IfroPratica_Testes.Test
{
    public class RpgCharacterController_Test
    {
        [Fact(DisplayName = "Get All Characters")]
        public async Task GetAllCharacters()
        {
            await using var application = new InmemoryContext();
            await InMemoryMock.CreateCharacters(application, true);
            var url = "/rpgchar";

            var client = application.CreateClient();
            var result = await client.GetAsync(url);

            var rpgChar = await client.GetFromJsonAsync<IEnumerable<Models.RpgCharacter>>("/rpgchar");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotEmpty(rpgChar);
            Assert.Equal(2, rpgChar.Count());
        }

        [Fact(DisplayName = "Get Empty Characters")]
        public async Task GetEmptyChars()
        {
            await using var application = new InmemoryContext();
            await InMemoryMock.CreateCharacters(application, false);

            var client = application.CreateClient();

            var rpgChar = await client.GetFromJsonAsync<IEnumerable<Models.RpgCharacter>>("/rpgchar");

            Assert.Empty(rpgChar);
            Assert.Equal(0, rpgChar.Count());
        }
    }
}
