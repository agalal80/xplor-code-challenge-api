using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XplorCodeChallenge.Application.Dtos;

namespace XplorCodeChallenge.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<IList<CustomerDto>> GetAllAsync();

        Task AddAsync(CustomerDto customer);

        Task UpdateAsync(CustomerDto customer);

        Task DeleteAsync(long customerId);

        Task<CustomerDto> GetById(long customerId);
    }
}
