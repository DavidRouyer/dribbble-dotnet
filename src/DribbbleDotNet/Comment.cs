namespace DribbbleDotNet
{
    using Newtonsoft.Json;

    public class Comment : Base
    {
        public string Body { get; set; }

        [JsonProperty(PropertyName = "likes_count")]
        public long LikesCount { get; set; }

        public Player Player { get; set; }
    }
}