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
    public class DepartmentControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {

        private InMemoryWebApplicationFactory<Program> _factory;

        public DepartmentControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task WepApiGetAllRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/departments");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WepApiGetByIdRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/departments/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WepApiPostRequestGetResponceSuccessTest()
        {
            DepartmentAddDto departmentAddDto = new DepartmentAddDto
            {
                CountryId = 1,
                DepartmentName = "Test"
            };
            HttpClient client = _factory.CreateClient();
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(departmentAddDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/departments", httpContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task WepApiPutRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            DepartmentUpdateDto departmentUpdateDto = new DepartmentUpdateDto
            {
                Id=1,
                CountryId = 1,
                DepartmentName = "Test"
            };

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(departmentUpdateDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("/api/departments", httpContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task WepApiDeleteRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("/api/departments/1");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
