﻿namespace BootcampHomework.Entities
{
    public class Country:BaseEntity
    {
        public string CountryName { get; set; }

        public string Continent { get; set; }

        public string Currency { get; set; }

        ////Relational Property
        //public virtual List<Department> Departments { get; set; }
    }
}
