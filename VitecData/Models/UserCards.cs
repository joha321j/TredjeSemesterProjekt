using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecData.Models
{
    public class UserCards
    {
        public int ID { get; set; }
        public Card Card { get; set; }
        public WebUser User { get; set; }
    }
}
