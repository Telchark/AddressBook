using AddressBook;
using AddressBook.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBookTests
{

    public class AddressBookTests : IClassFixture<AddressBookApplicationFactory<Startup>>
    {
        private readonly AddressBookApplicationFactory<Startup> _factory;

        public AddressBookTests(AddressBookApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetLast_ReturnsSuccessResultAndData()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/AddressBook");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AddressModel>(responseString);

            Assert.IsType<AddressModel>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetAll_ReturnsSuccessResultAndData()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/AddressBook/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AddressModel[]>(responseString);

            Assert.IsType<AddressModel[]>(result);
            Assert.Equal(4, result.Length);
        }
        [Fact]
        public async Task GetReturnsSuccessResultAndData()
        {
            var client = _factory.GetAnonymousClient();

            var city = "Bielsko-Biała";

            var response = await client.GetAsync($"/api/AddressBook/{city}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AddressModel[]>(responseString);

            Assert.IsType<AddressModel[]>(result);
            Assert.Equal(2,result.Length);
        }
        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var model = new AddressModel
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Country = "Country",
                City = "City",
                ZipCode = "ZipCode",
                Street = "Street",
                BuildingNumber = 35,
                LocalNumber = null
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/AddressBook", stringContent);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AddressModel>(responseString);

            Assert.IsType<AddressModel>(result);
            Assert.NotNull(result);
        }
    }
}
