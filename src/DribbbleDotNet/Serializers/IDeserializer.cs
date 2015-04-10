using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DribbbleDotNet.Serializers
{
    interface IDeserializer
    {
        Task<T> Deserialize<T>(HttpResponseMessage response);
        Task<object> Deserialize(HttpResponseMessage response, Type type);
    }
}
