using Core.Clients;
using RestSharp;
using Core.Utils;
using log4net;
using Business.Models;

namespace Business.Clients
{
    public class UserClient: BaseClient
    {
        private static readonly ILog Log = Logger.GetLogger<UserClient>();
        public UserClient() : base("https://jsonplaceholder.typicode.com") { }

        public async Task<RestResponse> GetUsersAsync()
        {
            Log.Info("Fetching all users...");
            var request = new RestRequest("users", Method.Get);
            var response = await Client.GetAsync(request);

            return response;
        }

        public async Task<RestResponse> CreateUserAsync(User user)
        {
            Log.Info($"Creating user with name: {user.Name}");
            var request = new RestRequest("users", Method.Post);
            request.AddJsonBody(user);
            var response = await Client.PostAsync(request);

            return response;
        }

        public async Task<RestResponse> InvalidEndpoint()
        {
            Log.Info("Sending request to invalid endpoint");
            var request = new RestRequest("invalidendpoint", Method.Get);
            var response = await Client.GetAsync(request);

            return response;
        }

    }
}
