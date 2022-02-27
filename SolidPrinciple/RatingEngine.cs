using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidPrinciple
{
    /// <summary>
    ///  The RatingEngine reads the policy application details from a file and
    ///  produces anumeric rating value base on the details
    ///  <summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public FilePolicySource FilePolicySource { get; set; } = new FilePolicySource();

        public JsonPolicySerializer JsonPolicySerializer { get; set; } = new JsonPolicySerializer();

        public decimal Rating { get; set; }

        public void Rate()
        {

            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            // load policy - open policy.jason
            string policyJson = FilePolicySource.GetPolicyFromSource();


            var policy = JsonPolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater?.Rate(policy);

            Logger.Log("Rating Completed.");
        }
    }
}
