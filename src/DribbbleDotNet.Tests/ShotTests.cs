using System.Threading.Tasks;
using Xunit;

namespace DribbbleDotNet.Tests
{
    public class ShotTests
    {
        [Fact]
        public async void Find()
        {
            Shot shot = await Shot.Find(21603);

            Assert.NotNull(shot);
            Assert.Equal(21603, shot.Id);
            Assert.Equal("Moon", shot.Title);
            Assert.Equal("http://dribbble.com/shots/21603-Moon", shot.Url);
            Assert.True(shot.ImageUrl.StartsWith("https://d13yacurqjgara.cloudfront.net/users/1/screenshots/21603/shot_1274474082.png"));
            Assert.True(shot.ImageTeaserUrl.StartsWith("https://d13yacurqjgara.cloudfront.net/users/1/screenshots/21603/shot_1274474082_teaser.png"));
			
            Assert.Equal(400, shot.Width);
            Assert.Equal(300, shot.Height);

            Assert.True(shot.ViewsCount >= 0);
            Assert.True(shot.LikesCount >= 0);
            Assert.True(shot.CommentsCount >= 0);
            Assert.True(shot.ReboundsCount >= 0);

            Assert.NotNull(shot.CreatedAt);
            Assert.NotNull(shot.Player);
        }

        [Fact]
        public async void Everyone()
        {
            PaginatedList<Shot> everyone = await Shot.Everyone(perPage:2);
            Assert.Equal(2, everyone.Items.Count);
        }

        [Fact]
        public async void Debuts()
        {
            PaginatedList<Shot> debuts = await Shot.Debuts(perPage: 2);
            Assert.Equal(2, debuts.Items.Count);
        }

        [Fact]
        public async void Popular()
        {
            PaginatedList<Shot> popular = await Shot.Popular(perPage: 2);
            Assert.Equal(2, popular.Items.Count);
        }

        [Fact]
        public async void Rebounds()
        {
            Shot shot = await Shot.Find(59714);
            PaginatedList<Shot> rebounds = await shot.Rebounds();

            foreach (Shot rebound in rebounds.Items)
            {
                Assert.NotNull(rebound.Player);
            }
        }

        [Fact]
        public async void Comments()
        {
            Shot shot = await Shot.Find(59714);
            PaginatedList<Comment> comments = await shot.Comments();
            Assert.NotEmpty(comments.Items);
            foreach (var comment in comments.Items)
            {
                Assert.NotNull(comment.Id);
                Assert.NotNull(comment.CreatedAt);
                Assert.NotEmpty(comment.Body);
                Assert.NotNull(comment.Player);
            }
        }
    }
}