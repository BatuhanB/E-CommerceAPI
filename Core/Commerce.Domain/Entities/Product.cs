using Commerce.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace Commerce.Domain.Entities
{
	public sealed class Product : BaseEntity
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public long Price{ get; set; }

		[JsonIgnore]
		public ICollection<Order>? Orders { get; set; }
	}
}
