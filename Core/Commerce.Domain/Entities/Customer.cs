using Commerce.Domain.Entities.Common;

namespace Commerce.Domain.Entities
{
	public sealed class Customer : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
