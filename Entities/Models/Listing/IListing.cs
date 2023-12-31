﻿namespace Entities.Models.Listing
{
    public interface IListing : IEntityBase
    {
        public decimal Price { get; set; }

        public string ImageName { get; set; }
    }
}