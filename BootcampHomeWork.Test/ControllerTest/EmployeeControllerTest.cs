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
    public class EmployeeControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _factory;

        public EmployeeControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task WepApiGetAllRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/Employees");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task WepApiGetByIdRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/Employees/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WepApiPostRequestGetResponceSuccessTest()
        {
            EmployeeAddDto employeeAddDto = new EmployeeAddDto
            {
                EmployeeName = "Fatih",
                DepartmentId = 1
            };

            HttpClient client = _factory.CreateClient();
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(employeeAddDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Employees", httpContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task WepApiPutRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            EmployeeUpdateDto employeeUpdateDto = new EmployeeUpdateDto
            {
                Id=2,
                EmployeeName = "Serdar",
                DepartmentId = 2
            };

            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(employeeUpdateDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("/api/Employees", httpContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task WepApiDeleteRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("/api/Employees/2");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task WepApiGetDetailsEmployeeRequestGetResponceSuccessTest()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/Employees/GetEmployeeDetails/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
