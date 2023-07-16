using Commerce.Domain.Entities.Common;

namespace Commerce.Domain.Dtos.Products
{
    public sealed class AddProductDto:BaseEntity
    {
        public required string Name { get; set; }
        public required int Stock { get; set; }
        public required long Price { get; set; }
    }
}
