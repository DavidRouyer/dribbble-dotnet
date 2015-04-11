using Xunit;

namespace DribbbleDotNet.Tests
{
    public class BaseTests
    {
        [Fact]
        public void Equality()
        {
            Assert.Equal(new Player { Id = 1 }, new Player { Id = 1 });
            Assert.Equal(new Shot { Id = 1 }, new Shot { Id = 1 });
            Assert.Equal(new Comment { Id = 1 }, new Comment { Id = 1 });

            Assert.NotEqual(new Player { Id = 1 }, new Player { Id = 2 });
            Assert.NotEqual(new Shot { Id = 1 }, new Shot { Id = 2 });
            Assert.NotEqual(new Comment { Id = 1 }, new Comment { Id = 2 });
        }
    }
}