using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NuBot.Tests.Fixtures;
using Xunit;

namespace NuBot.Tests.Unit
{
    public sealed class TextListenerTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Throws_If_Pattern_Is_Null()
            {
                // Given, When
                var exception = Assert.Throws<ArgumentNullException>(
                    () => new TextListener(null, _ => Task.CompletedTask));

                // Then
                Assert.Equal("pattern", exception.ParamName);
            }

            [Fact]
            public void Throws_If_Callback_Is_Null()
            {
                // Given, When
                var exception = Assert.Throws<ArgumentNullException>(
                    () => new TextListener(".*", null));

                // Then
                Assert.Equal("callback", exception.ParamName);
            }
        }

        public sealed class TheGetParametersMethod
        {
            [Fact]
            public void Returns_Empty_Collection_When_No_Groups()
            {
                // Given
                var message = new MessageFixture("some message").Build();
                var listener = new TextListener(".*", _ => Task.CompletedTask);

                // When
                var parameters = listener.GetParameters(message);

                // Then
                Assert.Empty(parameters);
            }

            [Fact]
            public void Returns_Collection_With_Single_Unnamed_Group()
            {
                // Given
                var message = new MessageFixture("some message").Build();
                var listener = new TextListener("(.*)", _ => Task.CompletedTask);

                // When
                var parameters = listener.GetParameters(message);

                // Then
                Assert.Equal(1, parameters.Count());
            }

            [Fact]
            public void Returns_Named_Parameters()
            {
                // Given
                var message = new MessageFixture("some message").Build();
                var listener = new TextListener("some (?<Foo>.*)", _ => Task.CompletedTask);

                // When
                var parameters = listener.GetParameters(message).ToList();

                // Then
                Assert.NotNull(parameters.SingleOrDefault(p => p.Name == "Foo"));
            }
        }
    }
}
