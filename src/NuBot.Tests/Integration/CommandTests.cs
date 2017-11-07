using System;
using System.Threading.Tasks;
using NuBot.Tests.Fixtures;
using Xunit;

namespace NuBot.Tests.Integration
{
    public sealed class CommandTests
    {
        public sealed class TheHearMethod
        {
            [Fact]
            public async Task Can_Hear_Simple_Command()
            {
                // Given
                var fixture = InMemoryBotFixture.Hear("ship it", async (ctx) => {
                    await ctx.SendAsync(":shipit:");
                });

                // When
                var response = await fixture.SendAsync("we should totally ship it!");

                // Then
                Assert.Equal(":shipit:", response);
            }
        }
    }
}
