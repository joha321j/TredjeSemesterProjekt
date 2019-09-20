using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecData.Models
{
    public class Card
    {
        public long cardID { get; set; }
        public int SecurityNumbers { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
