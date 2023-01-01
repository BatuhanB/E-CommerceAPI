namespace Commerce.Domain.Entities.Common
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
