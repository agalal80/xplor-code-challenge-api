using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XplorCodeChallenge.Application.Dtos;
using XplorCodeChallenge.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XplorCodeChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET: api/values
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<CustomerDto>> GetAsync()
        {
            return await _customerAppService.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            CustomerDto result = await _customerAppService.GetById(customerId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CustomerDto customer)
        {
            await _customerAppService.AddAsync(customer);
            return Ok();
        }

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] CustomerDto customer)
        {
            await _customerAppService.UpdateAsync(customer);
            return Ok();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            await _customerAppService.DeleteAsync(customerId);
            return Ok();
        }
    }
}
