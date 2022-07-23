using BootcampHomework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomeWork.Test.ControllerTest
{
    public class FolderControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _factory;

        public FolderControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task WepApiGetAllRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/folders");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WepApiGetByIdRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/folders/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WepApiPostRequestGetResponceSuccessTest()
        {
            FolderAddDto folderAddDto = new FolderAddDto
            {
                AccessType = "Dene",
                EmployeeId = 1
            };

            HttpClient client = _factory.CreateClient();
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(folderAddDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/folders",httpContent);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task WepApiPutRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            FolderUpdateDto folderUpdateDto = new FolderUpdateDto
            {
                Id=1,
                AccessType = "Dene",
                EmployeeId = 1
            };
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(folderUpdateDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("/api/folders", httpContent);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task WepApiDeleteRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("/api/folders/1");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
