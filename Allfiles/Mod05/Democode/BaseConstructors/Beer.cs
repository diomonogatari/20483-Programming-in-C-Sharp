using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConstructors
{
    class Beer : Beverage
    {
        public Beer()
        {
            // Use the default constructor to set default values.
            Cereal = "Not known";
            TypeOf = "Pilsner";
            CountryOfOrigin = "Not known";
        }

        public Beer(string name, bool isFairTrade, int servingTemp, string cereal, string type, string countryOfOrigin)
            : base(name, isFairTrade, servingTemp)
        {
            Cereal = cereal;
            TypeOf = type;
            CountryOfOrigin = countryOfOrigin;
        }

        public string Cereal { get; set; }
        public string TypeOf { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
