using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DribbbleDotNet.Serializers
{
    interface ISerializer
    {
        Encoding ContentEncoding { get; }
        string ContentType { get; }

        string Serialize(object instance, Type type);
    }
}
