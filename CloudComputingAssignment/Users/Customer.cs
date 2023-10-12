namespace Models.Users
{
    public class Customer : IUser
    {
        public Guid Id { get; } = EntityBaseExtensions.GenerateId();

        public string Name { get; set; }

        public string Email { get; set; }

        public Decimal MonthlyIncome { get; set; }

        public Customer()
        { }
    }
}