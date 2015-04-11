using Xunit;

namespace DribbbleDotNet.Tests
{
    public class PlayerTests
    {
        [Fact]
        public async void Find()
        {
            var player = await Player.Find(1);

            Assert.Equal(1, player.Id);
            Assert.Equal("simplebits", player.TwitterScreenName);
            Assert.Equal("Dan Cederholm", player.Name);
            Assert.Equal("simplebits", player.Username);
            Assert.Equal("Salem, MA", player.Location);
            
            Assert.NotNull(player.CreatedAt);
            Assert.Null(player.DraftedByPlayerId); // no-one drafted Dan

            Assert.Equal("http://dribbble.com/simplebits", player.Url);
            Assert.Equal("http://simplebits.com", player.WebSiteUrl);
            Assert.True(player.AvatarUrl.StartsWith("https://d13yacurqjgara.cloudfront.net/users/1/avatars/normal/4161c529fb7fe8d539bb71f73527c0aa.jpg?1424749681"));

            Assert.True(player.ShotsCount >= 0);

            Assert.True(player.FollowersCount >= 0);
            Assert.True(player.FollowingCount >= 0);

            Assert.True(player.LikesCount >= 0);
            Assert.True(player.LikesReceivedCount >= 0);

            Assert.True(player.ReboundsCount >= 0);
            Assert.True(player.ReboundsReceivedCount >= 0);

            Assert.True(player.DrafteesCount >= 0);

            Assert.True(player.CommentsCount >= 0);
            Assert.True(player.CommentsReceivedCount >= 0);
        }

        [Fact]
        public async void Shots()
        {
            Player player = await Player.Find(1);
            PaginatedList<Shot> shots = await player.Shots();
            Assert.Equal(15, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.Equal(player, shot.Player);
            }
            shots = await player.Shots(perPage:2);
            Assert.Equal(2, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.Equal(player, shot.Player);
            }
        }

        [Fact]
        public async void ShotsFollowing()
        {
            Player player = await Player.Find(1);
            PaginatedList<Shot> shots = await player.ShotsFollowing();
            Assert.Equal(15, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.NotEqual(player, shot.Player);
            }
            shots = await player.ShotsFollowing(perPage: 2);
            Assert.Equal(2, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.NotEqual(player, shot.Player);
            }
        }

        [Fact]
        public async void ShotsLikes()
        {
            Player player = await Player.Find(1);
            PaginatedList<Shot> shots = await player.ShotsLikes();
            Assert.Equal(15, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.NotEqual(player, shot.Player);
            }

            shots = await player.ShotsLikes(perPage: 2);
            Assert.Equal(2, shots.Items.Count);
            foreach (var shot in shots.Items)
            {
                Assert.NotNull(shot.Player);
                Assert.NotEqual(player, shot.Player);
            }
        }

        [Fact]
        public async void Followers()
        {
            Player player = await Player.Find(1);
            PaginatedList<Player> followers = await player.Followers();
            Assert.Equal(15, followers.Items.Count);

            followers = await player.Followers(perPage:2);
            Assert.Equal(2, followers.Items.Count);
        }

        [Fact]
        public async void Following()
        {
            Player player = await Player.Find(1);
            PaginatedList<Player> following = await player.Following();
            Assert.Equal(15, following.Items.Count);

            following = await player.Followers(perPage: 2);
            Assert.Equal(2, following.Items.Count);
        }

        [Fact]
        public async void Draftees()
        {
            Player player = await Player.Find(1);
            PaginatedList<Player> draftees = await player.Draftees();
            Assert.Equal(15, draftees.Items.Count);

            draftees = await player.Followers(perPage: 2);
            Assert.Equal(2, draftees.Items.Count);
        }
    }
}
