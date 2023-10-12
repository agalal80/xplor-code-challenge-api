using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JorgeSerrano.Json;
using XplorCodeChallenge.Core.Interfaces;
using XplorCodeChallenge.Core.Models;

namespace XplorCodeChallenge.Infrastructure.HttpClients
{
    public class CustomerHttpClient: ICustomerClient
    {
        private readonly HttpClient _httpClient;

        public CustomerHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");

            _httpClient = httpClient;
        }

        public async Task AddAsync(Customer customer)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy() };
            var serializedCustomer = JsonSerializer.Serialize(customer, options);
            using StringContent jsonContent = new StringContent(
               serializedCustomer,
               Encoding.UTF8,
               "application/json");
            var response = await _httpClient.PostAsync("Customer", jsonContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(long customerId)
        {
            var response = await _httpClient.DeleteAsync($"Customer/{customerId}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Customers");

            response.EnsureSuccessStatusCode();
            
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IList<Customer>>(responseStream, options);
        }

        public async Task<Customer> GetById(long customerId)
        {
            var response = await _httpClient.GetAsync($"Customer/{customerId}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<Customer>(responseStream, options);
        }

        public async Task UpdateAsync(Customer customer)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy() };
            var serializedCustomer = JsonSerializer.Serialize(customer, options);
            using StringContent jsonContent = new StringContent(
               serializedCustomer,
               Encoding.UTF8,
               "application/json");
            var response = await _httpClient.PostAsync($"Customer/{customer.Id}", jsonContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
