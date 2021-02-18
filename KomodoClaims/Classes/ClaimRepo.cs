using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Classes
{
    public class ClaimRepo
    {
        private List<Claim> _claimDirectory = new List<Claim>();

        public bool AddClaimToDirectory(Claim item)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(item);
            bool wasAdded = _claimDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<Claim> GetContents()
        {
            return _claimDirectory;
        }

        public Claim GetClaimByID(string name)
        {
            foreach (Claim item in _claimDirectory)
            {
                if (item.ClaimID.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateClaimByID(string name, Claim newClaim)
        {
            Claim item = GetClaimByID(name);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.ClaimID = newClaim.ClaimID;
                item.Type = newClaim.Type;
                item.Description = newClaim.Description;
                item.ClaimAmount = newClaim.ClaimAmount;
                item.DateOfIncident = newClaim.DateOfIncident;
                item.DateOfClaim = newClaim.DateOfClaim;
                item.IsValid = newClaim.IsValid;

                return true;
            }
        }

        public bool RemoveClaimByID(string name)
        {
            Claim item = GetClaimByID(name);

            if (item == null)
            {
                Console.WriteLine("Error");
                return false;
            }
            else
            {
                _claimDirectory.Remove(item);
                return true;
            }
        }



    }
}
