using Commerce.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderWriteRepository _orderWriteRepository;

		public OrdersController(IOrderWriteRepository orderWriteRepository)
		{
			_orderWriteRepository = orderWriteRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var result = await _orderWriteRepository.AddAsync(new()
			{
				Id = Guid.NewGuid(),
				Adress = "Istanbul/Turkey",
				Description = "Lorem IPSUM LOREM UPSUNMSMS",
				CustomerId = Guid.Parse("064fee40-21b1-4b84-9a73-12076267a3c7")
			});
			await _orderWriteRepository.SaveChanges();
			return Ok(result);
		}
	}
}
