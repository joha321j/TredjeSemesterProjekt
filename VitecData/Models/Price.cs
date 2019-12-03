using System;
using System.Collections.Generic;
using System.Text;

namespace VitecData.Models
{
    public class Price
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Valuta { get; set; }

        public override string ToString()
        {
            return Value + " " + Valuta;
        }
    }
}
