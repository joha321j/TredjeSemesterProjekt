using System;
using System.Collections.Generic;
using System.Text;

namespace VitecServices
{
    class IpAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime LoggedTime { get; set; }

        public IpAddress(string address)
        {
            Address = address;
            LoggedTime = DateTime.Now;
        }
    }
}
