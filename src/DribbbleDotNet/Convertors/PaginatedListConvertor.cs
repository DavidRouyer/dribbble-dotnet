namespace DribbbleDotNet.Convertors
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class PaginatedListConvertor<T> : JsonConverter
    {
        private readonly string itemsKey;

        public PaginatedListConvertor(string itemsKey)
        {
            if (string.IsNullOrEmpty(itemsKey)) 
                throw new ArgumentNullException("itemsKey");

            this.itemsKey = itemsKey;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteComment(value.ToString()); // Dribbble API is readonly so there is no point in doing the write.
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json = JObject.Load(reader);

            var paginatedList = new PaginatedList<T>();
            JsonConvert.PopulateObject(json.ToString(), paginatedList);

            var token = json[itemsKey];
            if (token != null && token.HasValues)
            {
                paginatedList.Items = new List<T>();
                JsonConvert.PopulateObject(token.ToString(), paginatedList.Items);
            }

            return paginatedList;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PaginatedList<T>);
        }
    }
}