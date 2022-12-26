using Commerce.Domain.Entities.Common;

namespace Commerce.Domain.Entities
{
	public class Customer : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
