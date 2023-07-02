using Commerce.Application.Repositories;
using Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Commerce.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;

        public CustomersController(ICustomerWriteRepository customerWriteRepository,
                                    ICustomerReadRepository customerReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerReadRepository.GetAll(tracking:false).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer model)
        {
            var result = await _customerWriteRepository.AddAsync(model);
            await _customerWriteRepository.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<bool> Update([FromBody] Customer model)
        {
            var customer = await _customerReadRepository.GetByIdAsync(model.Id);
            bool result = false;
            if (customer is not null)
            {
                result = _customerWriteRepository.Update(customer);
                await _customerWriteRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}
