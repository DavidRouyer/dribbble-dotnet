namespace DribbbleDotNet.Tests
{
    using NUnit.Framework;
    using System.Threading.Tasks;

    [TestFixture]
    public class ShotTests
    {
        [Test]
        public async void Find()
        {
            Shot shot = await Shot.Find(21603);

            Assert.NotNull(shot);
            Assert.AreEqual(21603, shot.Id);
            Assert.AreEqual("Moon", shot.Title);
            Assert.AreEqual("http://dribbble.com/shots/21603-Moon", shot.Url);
            Assert.That(shot.ImageUrl.StartsWith("https://d13yacurqjgara.cloudfront.net/users/1/screenshots/21603/shot_1274474082.png"));
            Assert.That(shot.ImageTeaserUrl.StartsWith("https://d13yacurqjgara.cloudfront.net/users/1/screenshots/21603/shot_1274474082_teaser.png"));
			
            Assert.AreEqual(400, shot.Width);
            Assert.AreEqual(300, shot.Height);

            Assert.GreaterOrEqual(shot.ViewsCount, 0);
            Assert.GreaterOrEqual(shot.LikesCount, 0);
            Assert.GreaterOrEqual(shot.CommentsCount, 0);
            Assert.GreaterOrEqual(shot.ReboundsCount, 0);

            Assert.IsNotNull(shot.CreatedAt);
            Assert.NotNull(shot.Player);
        }

        [Test]
        public async void Everyone()
        {
            PaginatedList<Shot> everyone = await Shot.Everyone(perPage:2);
            Assert.AreEqual(2, everyone.Items.Count);
        }

        [Test]
        public async void Debuts()
        {
            PaginatedList<Shot> debuts = await Shot.Debuts(perPage: 2);
            Assert.AreEqual(2, debuts.Items.Count);
        }

        [Test]
        public async void Popular()
        {
            PaginatedList<Shot> popular = await Shot.Popular(perPage: 2);
            Assert.AreEqual(2, popular.Items.Count);
        }

        [Test]
        public async void Rebounds()
        {
            Shot shot = await Shot.Find(59714);
            PaginatedList<Shot> rebounds = await shot.Rebounds();

            foreach (Shot rebound in rebounds.Items)
            {
                Assert.NotNull(rebound.Player);
            }
        }

        [Test]
        public async void Comments()
        {
            Shot shot = await Shot.Find(59714);
            PaginatedList<Comment> comments = await shot.Comments();
            Assert.IsNotEmpty(comments.Items);
            foreach (var comment in comments.Items)
            {
                Assert.NotNull(comment.Id);
                Assert.NotNull(comment.CreatedAt);
                Assert.IsNotEmpty(comment.Body);
                Assert.NotNull(comment.Player);
            }
        }
    }
}