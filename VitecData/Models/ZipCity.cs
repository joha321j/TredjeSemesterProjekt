using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VitecData.Models
{
    public class ZipCity
    {
        [Key]
        public int ZIP { get; set; }
        public string CityName { get; set; }
    }
}
