using log4net;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Core.Utils;

namespace Core.Clients
{
    public abstract class BaseClient
    {
        protected readonly RestClient Client;
        private static readonly ILog Log = Logger.GetLogger<BaseClient>();

        protected BaseClient(string baseUrl)
        {
            var serializerOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

            Client = new RestClient(
                options: new() { BaseUrl = new(baseUrl) },
                configureSerialization: s => s.UseSystemTextJson(serializerOptions));
            log4net.Config.XmlConfigurator.Configure();
            Log.Info($"BaseClient initialized with base URL: {baseUrl}");
        }
    }
}
