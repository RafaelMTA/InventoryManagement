﻿using IM.Domain.Enum;
using IM.Domain.ValueObjects;

namespace IM.Domain.Entities
{
    public abstract class Company : AuditableEntity
    {
        public string TradeName { get; set; }
        public string LegalName { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public CompanySegment CompanySegment { get; set; }
    }
}
