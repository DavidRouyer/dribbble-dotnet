namespace DribbbleDotNet
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PaginatedList<T>
    {
        public PaginatedList()
        {
            Items = new List<T>();
        }

        public int Page { get; set; }
        
        public int Pages { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        public List<T> Items { get; set; }
    }
}