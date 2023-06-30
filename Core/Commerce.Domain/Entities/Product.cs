using Commerce.Domain.Entities.Common;

namespace Commerce.Domain.Entities
{
	public sealed class Product : BaseEntity
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public long Price{ get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
