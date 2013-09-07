namespace DribbbleDotNet.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Find()
        {
            var player = Player.Find(1);

            Assert.AreEqual(1, player.Id);
            Assert.AreEqual("simplebits", player.TwitterScreenName);
            Assert.AreEqual("Dan Cederholm", player.Name);
            Assert.AreEqual("simplebits", player.Username);
            Assert.AreEqual("Salem, MA", player.Location);
            
            Assert.IsNotNull(player.CreatedAt);
            Assert.IsNull(player.DraftedByPlayerId); // no-one drafted Dan

            Assert.AreEqual("http://dribbble.com/simplebits", player.Url);
            Assert.AreEqual("http://simplebits.com", player.WebSiteUrl);
            Assert.That(player.AvatarUrl.StartsWith("http://dribbble.s3.amazonaws.com/users/1/avatars/normal/dc.jpg?1371675643"));

            Assert.GreaterOrEqual(player.ShotsCount, 0);

            Assert.GreaterOrEqual(player.FollowersCount, 0);
            Assert.GreaterOrEqual(player.FollowingCount, 0);
            
            Assert.GreaterOrEqual(player.LikesCount, 0);
            Assert.GreaterOrEqual(player.LikesReceivedCount, 0);

            Assert.GreaterOrEqual(player.ReboundsCount, 0);
            Assert.GreaterOrEqual(player.ReboundsReceivedCount, 0);

            Assert.GreaterOrEqual(player.DrafteesCount, 0);
            
            Assert.GreaterOrEqual(player.CommentsCount, 0);
            Assert.GreaterOrEqual(player.CommentsReceivedCount, 0);
        }

        [Test]
        public void Shots()
        {
            Player player = Player.Find(1);
            PaginatedList<Shot> shots = player.Shots();
            Assert.AreEqual(15, shots.Items.Count, "default page size");
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.AreEqual(player, shot.Player);
            }
            shots = player.Shots(perPage:2);
            Assert.AreEqual(2, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.AreEqual(player, shot.Player);
            }
        }

        [Test]
        public void ShotsFollowing()
        {
            Player player = Player.Find(1);
            PaginatedList<Shot> shots = player.ShotsFollowing();
            Assert.AreEqual(15, shots.Items.Count, "default page size");
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.AreNotEqual(player, shot.Player);
            }
            shots = player.ShotsFollowing(perPage: 2);
            Assert.AreEqual(2, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.AreNotEqual(player, shot.Player);
            }
        }

        [Test]
        public void ShotsLikes()
        {
            Player player = Player.Find(1);
            PaginatedList<Shot> shots = player.ShotsLikes();
            Assert.AreEqual(15, shots.Items.Count, "default page size");
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.AreNotEqual(player, shot.Player);
            }

            shots = player.ShotsLikes(perPage: 2);
            Assert.AreEqual(2, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.AreNotEqual(player, shot.Player);
            }
        }

        [Test]
        public void Followers()
        {
            Player player = Player.Find(1);
            PaginatedList<Player> followers = player.Followers();
            Assert.AreEqual(15, followers.Items.Count, "default page size");

            followers = player.Followers(perPage:2);
            Assert.AreEqual(2, followers.Items.Count);
        }

        [Test]
        public void Following()
        {
            Player player = Player.Find(1);
            PaginatedList<Player> following = player.Following();
            Assert.AreEqual(15, following.Items.Count, "default page size");

            following = player.Followers(perPage: 2);
            Assert.AreEqual(2, following.Items.Count);
        }

        [Test]
        public void Draftees()
        {
            Player player = Player.Find(1);
            PaginatedList<Player> draftees = player.Draftees();
            Assert.AreEqual(15, draftees.Items.Count, "default page size");

            draftees = player.Followers(perPage: 2);
            Assert.AreEqual(2, draftees.Items.Count);
        }
    }
}
