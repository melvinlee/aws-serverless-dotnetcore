using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ProfileServerless
{
    public class Functions
    {
        private Stopwatch _stopWatch;

        public Functions()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        public APIGatewayProxyResponse GetProfile(APIGatewayProxyRequest request, ILambdaContext context)
        {                     
            context.Logger.LogLine("Get Request\n");

            var profile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText(@"profile.json"));

            _stopWatch.Stop();

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(profile, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()}),
                Headers = new Dictionary<string, string> {
                    { "Content-Type", "application/json" },
                    { "X-Processing-Time", $"{_stopWatch.ElapsedMilliseconds} ms"}
                }
            };

            return response;
        }
    }
}
