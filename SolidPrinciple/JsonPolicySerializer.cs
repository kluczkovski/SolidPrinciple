using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidPrinciple
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString,
                new StringEnumConverter());
        }
    }
}
