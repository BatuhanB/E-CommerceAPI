using Commerce.Domain.Entities.Common;

namespace Commerce.Domain.Entities
{
    public sealed class Order:BaseEntity
	{
		public string Description { get; set; }
		public string Adress { get; set; }
		public Guid CustomerId { get; set; }
		public Customer Customer { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
