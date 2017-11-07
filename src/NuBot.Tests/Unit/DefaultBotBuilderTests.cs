using System;
using NuBot;
using Xunit;

namespace NuBot.Tests.Unit
{
    public sealed class DefaultBotBuilderTests
    {
        public sealed class TheUseAdapterMethod
        {
            [Fact]
            public void Throws_If_Chat_Adapter_Is_Null()
            {
                // Given
                var builder = new DefaultBotBuilder();

                // When
                var exception = Assert.Throws<ArgumentNullException>(() => builder.UseAdapter(null));

                // Then
                Assert.Equal("chatAdapter", exception.ParamName);
            }
        }
    }
}
