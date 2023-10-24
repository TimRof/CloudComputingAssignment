using System.ComponentModel.DataAnnotations;

namespace Entities.Models.User
{
    public class Customer : IUser
    {
        [Key]
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();

        public string Name { get; set; }

        public string Email { get; set; }

        public decimal MonthlyIncome { get; set; }

        public Customer()
        { }
    }
}