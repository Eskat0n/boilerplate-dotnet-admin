using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PusherServer;

namespace Boilerplate.Jobs.Announcers.Pusher
{
    public class PusherJsonSerializer : ISerializeObjectsToJson
    {
        private static readonly JsonSerializerSettings Settings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Converters = new List<JsonConverter> {new StringEnumConverter()}
        };

        public string Serialize(object objectToSerialize) =>
            JsonConvert.SerializeObject(objectToSerialize, Settings);
    }
}