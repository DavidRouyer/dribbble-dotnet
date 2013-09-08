namespace DribbbleDotNet
{
    using System;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Shot : Base
    {
        public async static Task<Shot> Find(int id)
        {
            var request = client.BaseAddress + string.Format("shots/{0}", id);
            var response = await client.GetAsync(request);
            return Deserialize<Shot>(await response.Content.ReadAsStringAsync());
        }

        public async static Task<PaginatedList<Shot>> Debuts(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("shots/debuts"))
            };

            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public async static Task<PaginatedList<Shot>> Everyone(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("/shots/everyone"))
            };

            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public async static Task<PaginatedList<Shot>> Popular(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("/shots/popular"))
            };

            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public string Title { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "short_url")]
        public string ShortUrl { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "image_teaser_url")]
        public string ImageTeaserUrl { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        [JsonProperty(PropertyName = "views_count")]
        public long ViewsCount { get; set; }

        [JsonProperty(PropertyName = "likes_count")]
        public long LikesCount { get; set; }

        [JsonProperty(PropertyName = "comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty(PropertyName = "rebounds_count")]
        public long ReboundsCount { get; set; }

        public Player Player { get; set; }

        public async Task<PaginatedList<Shot>> Rebounds(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("/shots/{0}/rebounds", Id))
            };

            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Shot>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<PaginatedList<Comment>> Comments(int page = 1, int perPage = 15)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress + string.Format("/shots/{0}/comments", Id))
            };

            SetPaginationParameters(request, page, perPage);
            var response = await client.SendAsync(request);
            return Deserialize<PaginatedList<Comment>>(await response.Content.ReadAsStringAsync());
        }
    }
}