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
            public async Task Can_Hear_Things()
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

            [Fact]
            public async Task Can_Hear_Things_With_Parameters()
            {
                // Given
                var fixture = InMemoryBotFixture.Hear("Hello (?<Name>[\\w]+)", async (ctx) => {
                    await ctx.SendAsync(ctx.Parameters["Name"].ToString());
                });

                // When
                var response = await fixture.SendAsync("Hello NuBot :waves:");

                // Then
                Assert.Equal("NuBot", response);
            }

            [Fact]
            public async Task Can_Hear_Case_Insensitive_Things()
            {
                // Given
                var fixture = InMemoryBotFixture.Hear("hElO", async (ctx) => {
                    await ctx.SendAsync("OK");
                });

                // When
                var response = await fixture.SendAsync("helo");

                // Then
                Assert.Equal("OK", response);
            }
        }

        public class TheRespondMethod
        {
            [Theory]
            [InlineData("@TestBot Test")]
            [InlineData("TestBot Test")]
            public async Task Responds_When_Mentioned(string message)
            {
                // Given
                var fixture = InMemoryBotFixture.Respond("Test", async (ctx) =>
                {
                    await ctx.SendAsync("OK");
                });

                // When
                var response = await fixture.SendAsync(message);

                // Then
                Assert.Equal("OK", response);
            }

            [Theory]
            [InlineData("foo @TestBot hello")]
            [InlineData("foo TestBot hello")]
            public async Task Ignores_Mid_Sentence_Mentions(string message)
            {
                // Given
                var fixture = InMemoryBotFixture.Respond("hello", async (ctx) => {
                    await ctx.SendAsync("Shouldn't happen!");
                });

                // When
                var response = await fixture.SendAsync(message);

                // Then
                Assert.Equal(string.Empty, response);
            }
        }
    }
}
