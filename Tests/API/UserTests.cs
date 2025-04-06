using System.Net;
using System.Text.Json;
using Business.Clients;
using Business.Models;
using Core.Utils;
using log4net;
using NUnit.Framework;


namespace Tests.API
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class UserTests
    {
        private static readonly ILog Log = Logger.GetLogger<UserTests>();
        public UserClient UserClient { get; set; }

        [SetUp]
        public void Setup()
        {
            UserClient = new UserClient();
        }


        [Test]
        [Category("API")]
        public async Task ValidateThatUserListAndFields()
        {
            var usersResponse = await UserClient.GetUsersAsync();

            var users = JsonSerializer.Deserialize<List<User>>(usersResponse.Content);
            if (users is null)
            {
                Log.Error("Users is null");
                Assert.Fail("Users is null");
                return;
            }

            Log.Info($"Users count: {users.Count}");

            var user = users.First();
            if (user is null)
            {
                Assert.Fail("First User is null");
                return;
            }
            Assert.Multiple(() =>
            {
                Assert.That(users.Count, Is.GreaterThan(0), "Users count is 0");
                Assert.That(user.Id, Is.Not.Null, "Id is null");
                Assert.That(user.Name, Is.Not.Null, "Name is null");
                Assert.That(user.Username, Is.Not.Null, "Username is null");
                Assert.That(user.Email, Is.Not.Null, "Email is null");
                Assert.That(user.Address, Is.Not.Null, "Address is null");
                Assert.That(user.Phone, Is.Not.Null, "Phone is null");
                Assert.That(user.Website, Is.Not.Null, "Website is null");
                Assert.That(user.Company, Is.Not.Null, "Company is null");
                Assert.That(usersResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");

            }
        );
        }


        [Test]
        [Category("API")]
        public async Task ValidateResponseHeaderForUsers()
        {
            var usersResponse = await UserClient.GetUsersAsync();

            Log.Info($"Content-Type: {usersResponse.ContentType}");
            var contentType = usersResponse.ContentType;
            Assert.That(contentType, Is.EqualTo("application/json; charset=utf-8"), "Content type is not application/json; charset=utf-8");
            Assert.That(usersResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
        }

        [Test]
        [Category("API")]
        public async Task ValidateResponseBodyForUsers()
        {
            var usersResponse = await UserClient.GetUsersAsync();

            var users = JsonSerializer.Deserialize<List<User>>(usersResponse.Content);
            if (users is null)
            {
                Log.Error("Users is null");
                Assert.Fail("Users is null");
                return;
            }

            Assert.Multiple(() =>
            {
                Assert.That(users.Count, Is.EqualTo(10), "There should be exactly 10 users.");
                // Each user should have a different ID
                Assert.That(users.Select(u => u.Id).Distinct().Count(), Is.EqualTo(10), "Each user should have a different ID.");
                Log.Info($"Users count: {users.Count}");

                foreach (var user in users)
                {
                    Assert.That(user?.Id, Is.Not.Null, "User ID is null");
                    Assert.That(user?.Name, Is.Not.Empty, "User name is empty");
                    Assert.That(user?.Username, Is.Not.Empty, "User username is empty");
                    Assert.That(user?.Company?.Name, Is.Not.Empty, "User company name is empty");
                }
                Assert.That(usersResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            });
        }


        [Test]
        [TestCase("Test User", "testuser")]
        [Category("API")]
        public async Task ValidateUserCreation(string name, string username)
        {
            var user = new User { Name = name, Username = username };

            var response = await UserClient.CreateUserAsync(user);

            var createdUser = JsonSerializer.Deserialize<User>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(createdUser?.Id, Is.Not.Null, "User ID is missing");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code is not 201");
            });
        }

        [Test]
        [Category("API")]
        public async Task ValidateInvalidEndpoint()
        {
            var response = await UserClient.InvalidEndpoint();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code is not 404");
        }

        [TearDown]
        public void TearDown()
        {
            UserClient = null;
        }
    }
}
