namespace DribbbleDotNet
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Player : Base
    {
        public async static Task<Player> Find(int id)
        {
            return await Find(id.ToString());
        }

        public async static Task<Player> Find(string username)
        {
            var request = client.BaseAddress + string.Format("players/{0}", username);
            var response = await client.GetAsync(request);
            return Deserialize<Player>(await response.Content.ReadAsStringAsync());
        }

        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string Location { get; set; }
        
        [JsonProperty(PropertyName = "twitter_screen_name")]
        public string TwitterScreenName { get; set; }

        [JsonProperty(PropertyName = "drafted_by_player_id")]
        public long? DraftedByPlayerId { get; set; }

        public string Url { get; set; }
        
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "website_url")] 
        public string WebSiteUrl { get; set; }

        [JsonProperty(PropertyName = "shots_count")]
        public long ShotsCount { get; set; }

        [JsonProperty(PropertyName = "followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty(PropertyName = "following_count")]
        public long FollowingCount { get; set; }

        [JsonProperty(PropertyName = "likes_count")]
        public long LikesCount { get; set; }

        [JsonProperty(PropertyName = "likes_received_count")]
        public long LikesReceivedCount { get; set; }

        [JsonProperty(PropertyName = "rebounds_count")]
        public long ReboundsCount { get; set; }

        [JsonProperty(PropertyName = "rebounds_received_count")]
        public long ReboundsReceivedCount { get; set; }

        [JsonProperty(PropertyName = "draftees_count")]
        public long DrafteesCount { get; set; }

        [JsonProperty(PropertyName = "comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty(PropertyName = "comments_received_count")]
        public long CommentsReceivedCount { get; set; }

        public async Task<PaginatedList<Shot>> Shots(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("players/{0}/shots", Id))
            };
            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<PaginatedList<Shot>> ShotsFollowing(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("players/{0}/shots/following", Id))
            };
            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<PaginatedList<Shot>> ShotsLikes(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("players/{0}/shots/likes", Id))
            };
            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<PaginatedList<Player>> Followers(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("players/{0}/followers", Id))
            };
            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Player>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<PaginatedList<Player>> Following(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("players/{0}/following", Id))
            };
            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Player>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<PaginatedList<Player>> Draftees(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("players/{0}/draftees", Id))
            };
            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Player>>(await response.Content.ReadAsStringAsync());
        }
    }
}
