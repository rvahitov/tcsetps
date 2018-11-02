using System;
using System.Configuration;
using Autofac;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;

namespace Correct.Storage.Portal.Autofac
{
    public class RestClientModule : Module
    {
        private readonly Uri _respApiConnectionUri;

        public RestClientModule()
        {
            var url = ConfigurationManager.AppSettings["RestApi.ConnectionUrl"];
            _respApiConnectionUri = new Uri(url, UriKind.Absolute);
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ =>
            {
                var restClient = new RestClient(_respApiConnectionUri);
                restClient.ClearHandlers();
                restClient.AddHandler(new NewtonsoftJsonSerializer(), "application/json");
                return restClient;
            }).As<IRestClient>();
        }
    }
}