using Commerce.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace Commerce.Domain.Entities
{
	public sealed class Customer : BaseEntity
	{
		public string Name { get; set; }

		[JsonIgnore]
		public ICollection<Order>? Orders { get; set; }
	}
}
