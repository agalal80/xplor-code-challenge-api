using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using XplorCodeChallenge.Application.Dtos;
using XplorCodeChallenge.Application.Interfaces;
using XplorCodeChallenge.Core.Interfaces;
using XplorCodeChallenge.Core.Models;

namespace XplorCodeChallenge.Application.Services
{
    public class CustomerAppService: ICustomerAppService
    {
        private readonly ICustomerClient _customerClient;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerClient customerClient, IMapper mapper)
        {
            _customerClient = customerClient;
            _mapper = mapper;
        }

        public async Task AddAsync(CustomerDto customer)
        {
            var customerModel = _mapper.Map<Customer>(customer);
            await _customerClient.AddAsync(customerModel);
        }

        public async Task DeleteAsync(long customerId)
        {
            await _customerClient.DeleteAsync(customerId);
        }

        public async Task<IList<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerClient.GetAllAsync();
            return _mapper.Map<IList<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetById(long customerId)
        {
            var customer = await _customerClient.GetById(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task UpdateAsync(CustomerDto customer)
        {
            var customerModel = _mapper.Map<Customer>(customer);
            await _customerClient.UpdateAsync(customerModel);
        }
    }
}
