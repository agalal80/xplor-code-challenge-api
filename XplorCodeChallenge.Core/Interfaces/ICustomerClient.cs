using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XplorCodeChallenge.Core.Models;

namespace XplorCodeChallenge.Core.Interfaces
{
    public interface ICustomerClient
    {
        Task<IList<Customer>> GetAllAsync();

        Task AddAsync(Customer customer);

        Task UpdateAsync(Customer customer);
            
        Task DeleteAsync(long customerId);

        Task<Customer> GetById(long customerId);
    }
}
    