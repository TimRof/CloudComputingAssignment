using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mortgage
{
    public class MortgageApplicationRepository : BaseRepository<MortgageApplicationContext, MortgageApplication>, IMortgageApplicationRepository
    {
        public MortgageApplicationRepository(MortgageApplicationContext mortgageContext) : base(mortgageContext)
        {
            
        }
        public MortgageApplication GetApplicationByUserId(Guid userId)
        {
            return _context.MortgageApplication.FirstOrDefault(app => app.Applicant.Id == userId);
        }

        public void SetApplicationStatus(Guid id, MortgageApplicationStatus status)
        {
            _context.MortgageApplication.FirstOrDefault(app => app.Id == id).Status = status;
        }
    }
}
