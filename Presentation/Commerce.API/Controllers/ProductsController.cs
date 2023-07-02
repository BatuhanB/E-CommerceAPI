using Commerce.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.API.Controllers
{
	[Route("api/[controller]/[action]")]
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
		public async Task<IActionResult> GetAll()
		{
			var data = _readRepository.GetAll();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _readRepository.GetByIdAsync(id);
			return Ok(result);
		}
	}
}
