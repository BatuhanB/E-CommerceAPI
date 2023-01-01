using Commerce.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.API.Controllers
{
	[Route("api/[controller]")]
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

		[HttpGet("[action]")]
		public async Task<IActionResult> Add()
		{
			var result = await _customerWriteRepository.AddAsync(new()
			{
				Id = Guid.NewGuid(),
				Name = "Batuhan Balı"
			});
			await _customerWriteRepository.SaveChanges();
			return Ok(result);
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> Update()
		{
			var customer = await _customerReadRepository.GetByIdAsync("064fee40-21b1-4b84-9a73-12076267a3c7");
			customer.Name = "Batuhan";
			var result = _customerWriteRepository.Update(customer);
			await _customerWriteRepository.SaveChanges();
			return Ok(customer);
		}
	}
}
