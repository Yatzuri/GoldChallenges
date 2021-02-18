using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesKI.Classes
{
    public class BadgeRepo
    {
        private List<Badge> _badgeDirectory = new List<Badge>();
        Dictionary<string, List<string>> badgeDictionary = new Dictionary<string, List<string>>();

        public bool AddBadgeToDirectory(Badge item)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(item);
            bool wasAdded = _badgeDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<Badge> GetBadgeList()
        {
            return _badgeDirectory;
        }

        public Badge GetBadgeByID(string idName)
        {

            foreach (var item in _badgeDirectory)
            {
                if (item.BadgeID.ToLower() == idName.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateBadgeByID(string idName, Badge newBadge)
        {
            Badge item = GetBadgeByID(idName);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.BadgeID = newBadge.BadgeID;
                item.DoorNames = newBadge.DoorNames;
                return true;
            }
        }

        public void DictionarySeed()
        {
            List<string> _a1DoorList = new List<string>();  
            Badge a1 = new Badge("A1", _a1DoorList);
            _a1DoorList.Add("B1"); 
            _a1DoorList.Add("B2"); 
            badgeDictionary.Add(a1.BadgeID, _a1DoorList);
            _badgeDirectory.Add(a1);

            List<string> _a2DoorList = new List<string>(); 
            Badge a2 = new Badge("A2", _a2DoorList); 
            _a2DoorList.Add("B2");
            badgeDictionary.Add("A2", _a2DoorList); 
            _badgeDirectory.Add(a2);

            List<string> _a3DoorList = new List<string>(); 
            Badge a3 = new Badge("A3", _a3DoorList); 
            _a3DoorList.Add("B2"); 
            _a3DoorList.Add("B3");
            badgeDictionary.Add("A3", _a3DoorList);
            _badgeDirectory.Add(a3);

            List<string> _a4DoorList = new List<string>(); 
            Badge a4 = new Badge("A4", _a4DoorList); 
            _a4DoorList.Add("B2");
            _a4DoorList.Add("B4"); 
            badgeDictionary.Add("B4", _a4DoorList);  
            _badgeDirectory.Add(a4);

        }

        public void ConvertListToDictionary()
        {
            badgeDictionary.Clear();
            List<Badge> listOfBadges = GetBadgeList();
            foreach (Badge line in listOfBadges)
            {
                badgeDictionary.Add(line.BadgeID, line.DoorNames);
            }

        }
    }
}
