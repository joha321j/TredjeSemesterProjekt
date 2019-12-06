using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductAPIVitec.Models
{
    public class IpAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime LoggedTime { get; set; }
    }
}
