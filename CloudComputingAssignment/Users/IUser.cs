namespace Models.Users
{
    public interface IUser : IEntityBase
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}