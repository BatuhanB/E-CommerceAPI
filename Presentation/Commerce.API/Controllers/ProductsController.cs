using Commerce.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductReadRepository _readRepository;
		private readonly IProductWriteRepository _writeRepository;

		public ProductsController(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
		{
			_readRepository = readRepository;
			_writeRepository = writeRepository;
		}

		[HttpGet]
		public async void Get()
		{
			await _writeRepository.AddRangeAsync(new()
			{
				new () { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Product 1", Price = 120, Stock = 20 },
				new () { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Product 2", Price = 130, Stock = 40 },
				new () { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Product 3", Price = 150, Stock = 60 }
			});
			await _writeRepository.SaveChanges();
		}
	}
}
