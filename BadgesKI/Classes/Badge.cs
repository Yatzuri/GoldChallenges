using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesKI.Classes
{
    public class Badge
    {
        public string BadgeID { get; set; }
        public List<string> DoorNames { get; set; }


        public Badge()
        {

        }

        public Badge(string badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
