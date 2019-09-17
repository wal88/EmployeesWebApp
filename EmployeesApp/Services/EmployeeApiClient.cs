using EmployeesApp.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeesApp.Services
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private IConfiguration Config;

        public EmployeeApiClient(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            HttpClientFactory = httpClientFactory;
            Config = config;
        }

        public async Task<List<Employees>> GetEmployees()
        {
            var client = HttpClientFactory.CreateClient();
            var response = await client.GetAsync(Config["EmployeesApiUrl"]);
            response.EnsureSuccessStatusCode();
            var employees = JsonConvert.DeserializeObject<List<Employees>>(await response.Content.ReadAsStringAsync());
            return employees;
        }

        public async Task AddEmployee(Employees employee)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(employee), System.Text.Encoding.UTF8, "application/json");
            var client = HttpClientFactory.CreateClient();
            var response = await client.PostAsync(Config["EmployeesApiUrl"], requestBody);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEmployee(Employees employee)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(employee), System.Text.Encoding.UTF8, "application/json");
            var client = HttpClientFactory.CreateClient();
            var response = await client.PutAsync(Config["EmployeesApiUrl"], requestBody);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployee(string employeeNumber)
        {
            var client = HttpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{Config["EmployeesApiUrl"]}/{employeeNumber}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Departments>> GetDepartments()
        {
            var client = HttpClientFactory.CreateClient();
            var response = await client.GetAsync($"{ Config["EmployeesApiUrl"] }/Departments");
            response.EnsureSuccessStatusCode();
            var departments = JsonConvert.DeserializeObject<List<Departments>>(await response.Content.ReadAsStringAsync());
            return departments;
        }
    }

    public interface IEmployeeApiClient
    {
        Task<List<Employees>> GetEmployees();
        Task AddEmployee(Employees employee);
        Task UpdateEmployee(Employees employee);
        Task DeleteEmployee(string employeeNumber);
        Task<List<Departments>> GetDepartments();
    }
}
