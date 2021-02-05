﻿using System;

namespace Hahn.ApplicationProcess.December2020.Domain.DTO
{
    public class Applicant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
