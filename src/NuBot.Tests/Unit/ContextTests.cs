using System;
using NSubstitute;
using NuBot.Adapters;
using Xunit;

namespace NuBot.Tests.Unit
{
    public sealed class ContextTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Throws_If_Chat_Adapter_Is_Null()
            {
                // Given, When
                var exception = Assert.Throws<ArgumentNullException>(
                    () => new Context(null, Substitute.For<IMessage>(), Substitute.For<IParameterCollection>()));

                // Then
                Assert.Equal("chatAdapter", exception.ParamName);
            }

            [Fact]
            public void Throws_If_Message_Is_Null()
            {
                // Given, When
                var exception = Assert.Throws<ArgumentNullException>(
                    () => new Context(Substitute.For<IChatAdapter>(), null, Substitute.For<IParameterCollection>()));

                // Then
                Assert.Equal("message", exception.ParamName);
            }

            [Fact]
            public void Throws_If_Parameter_Collection_Is_Null()
            {
                // Given, When
                var exception = Assert.Throws<ArgumentNullException>(
                    () => new Context(Substitute.For<IChatAdapter>(), Substitute.For<IMessage>(), null));

                // Then
                Assert.Equal("parameterCollection", exception.ParamName);
            }
        }
    }
}
