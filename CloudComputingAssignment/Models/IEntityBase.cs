namespace Entities.Models
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }

    public static class EntityBaseExtensions
    {
        public static Guid GenerateId()
        {
            return Guid.NewGuid();
        }
    }
}
