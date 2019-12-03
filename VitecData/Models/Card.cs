using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VitecData.Models
{
    public class Card
    {
        [ProtectedPersonalData]
        public long cardID { get; set; }

        [ProtectedPersonalData]
        public int SecurityNumbers { get; set; }

        [ProtectedPersonalData]
        public DateTime ExpDate { get; set; }
    }
}
