using BootcampHomework.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BootcampHomeWork.Test
{
    public class CountryControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {

        private InMemoryWebApplicationFactory<Program> _factory;

        public CountryControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WepApiGetAllRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/countries");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task WepApiGetByIdRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/Countries/2");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task WepApiPostRequestGetResponceSuccessTest()
        {
            CountryAddDto countryAddDto = new CountryAddDto
            {
                CountryName="Belçika",
                Continent="Avrupa",
                Currency="EUR"
            };

            HttpClient client = _factory.CreateClient();
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(countryAddDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Countries", httpContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task WepApiPutRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            CountryUpdateDto countryUpdateDto = new CountryUpdateDto
            {
                Id = 1,
                CountryName = "Fransa",
                Continent = "Avrupa",
                Currency = "EUR"
            };

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(countryUpdateDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("/api/Countries", httpContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task WepApiDeleteRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("/api/Countries/1");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
