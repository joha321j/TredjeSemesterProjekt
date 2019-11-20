using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPIVitec.Models
{
    public class ZipCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Zip { get; set; }

        public string CityName { get; set; }
    }
}
