using Commerce.Application.Repositories;
using Commerce.Application.RequestParameters;
using Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Commerce.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductsController(IProductReadRepository readRepository,
            IProductWriteRepository writeRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            var totalCount = _readRepository.GetAll(false).Count();
            var data = await _readRepository.GetAll(false).Skip((pagination.Page - 1) * pagination.Size).Take(pagination.Size).ToListAsync();
            return Ok(new
            {
                totalCount,
                data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _readRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product model)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                result = await _writeRepository.AddAsync(model);
                await _writeRepository.SaveChangesAsync();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _writeRepository.Remove(id);
            await _writeRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            var files = Request.Form.Files;

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resources", "product-images");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);


            foreach (var item in files)
            {
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";
                string fullPath = Path.Combine(uploadPath, randomFileName);
                using FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await item.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }
    }
}
