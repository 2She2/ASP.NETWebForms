//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace World
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
            this.Languages = new HashSet<Language>();
        }
    
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> SurfaceArea { get; set; }
        public Nullable<int> Population { get; set; }
        public byte[] FlagImage { get; set; }
        public int ContinentId { get; set; }
    
        public virtual ICollection<City> Cities { get; set; }
        public virtual Continent Continent { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
    }
}
