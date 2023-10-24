using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mortgage
{
    public interface IMortgageApplicationRepository : IBaseRepository<MortgageApplicationContext, MortgageApplication>
    {
        public MortgageApplication GetApplicationByUserId(Guid userId);
        public void SetApplicationStatus(Guid userId, MortgageApplicationStatus status);
    }
}
