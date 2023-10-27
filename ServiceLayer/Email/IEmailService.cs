using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Email
{
    public interface IEmailService
    {
        void SendMortgageOfferEmail(string userEmail, Guid mortgageGuid);
    }
}
