﻿using Entities.Models.Mortgage;
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
    public class MortgageRepository : BaseRepository<MortgageContext, MortgageApplication>, IMortgageRepository
    {
        public MortgageRepository(MortgageContext mortgageContext) : base(mortgageContext)
        {
            
        }

        public void AddMortgageOffer(MortgageOffer offer)
        {
            _context.MortgageOffers.Add(offer);
        }

        public MortgageApplication GetApplicationByUserId(Guid userId)
        {
            return _context.MortgageApplications.FirstOrDefault(app => app.Applicant.Id == userId);
        }

        public MortgageOffer GetMortgageOfferByApplicationId(Guid applicationId)
        {
            return _context.MortgageOffers.FirstOrDefault(offer => offer.Application.Id == applicationId);
        }

        public MortgageOffer GetMortgageOfferById(Guid token)
        {
            return _context.MortgageOffers.FirstOrDefault(offer => offer.Id == token);
        }

        public MortgageOffer GetMortgageOfferByUserId(Guid applicationId)
        {
            return _context.MortgageOffers.FirstOrDefault(offer => offer.Application.Applicant.Id == applicationId);
        }

        public void SetApplicationStatus(Guid id, MortgageApplicationStatus status)
        {
            _context.MortgageApplications.FirstOrDefault(app => app.Id == id).Status = status;
        }
    }
}