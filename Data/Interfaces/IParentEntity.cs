namespace Data.Interfaces
{
	public interface IParentEntity
	{
		int Id { get; }
		int? ParentId { get; }
		string Name { get; }
	}
}