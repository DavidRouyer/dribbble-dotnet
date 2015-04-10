namespace DribbbleDotNet
{
    using System;
    using System.Collections.Generic;
    using Convertors;
    using Newtonsoft.Json;
    using Serializers;
    using System.Net.Http;

    public abstract class Base
    {
        private static readonly JsonSerializerSettings settings;
        private static readonly DribbbleSerializer serializer;
        protected static HttpClient client;
        
        static Base()
        {
            settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                Converters = new List<JsonConverter>()
                {
                    new PaginatedListConvertor<Player>("players"),
                    new PaginatedListConvertor<Shot>("shots"),
                    new PaginatedListConvertor<Comment>("comments"),
                }
            };

            serializer = new DribbbleSerializer(settings);

            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.dribbble.com");
            client.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
            client.DefaultRequestHeaders.Add("User-Agent", "DribbbleDotNet");
        }

        public long Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        public bool Equals(Base other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return Equals((Base) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Base left, Base right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Base left, Base right)
        {
            return !Equals(left, right);
        }

        protected static void SetPaginationParameters(HttpRequestMessage request, int page, int perPage)
        {
            request.RequestUri = new Uri(request.RequestUri.AbsoluteUri + "?page=" + page.ToString() + "&per_page=" + perPage.ToString());
        }

        protected static T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}