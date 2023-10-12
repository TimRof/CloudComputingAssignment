namespace Models
{
    public interface IEntityBase
    {
        Guid Id { get; }
    }

    public static class EntityBaseExtensions
    {
        public static Guid GenerateId()
        {
            return Guid.NewGuid();
        }
    }
}
