using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public static class CreationCheck
    {
        public static async Task<string> CanPlayerBeCreated(string FirstName, string LastName, bool Gender, int FederationNumber)
        {

            bool success = await PlayerData.ExistingFederationNumber(FederationNumber);

            if (success)
            {
                return "ExistingFederationNumber";
            }
            else if (string.IsNullOrWhiteSpace(FirstName))
            {
                return "NoFirstName";
            }
            else if (string.IsNullOrWhiteSpace(LastName))
            {
                return "NoLastName";
            }
            else if (FederationNumber == 0) // or whatever default invalid value you use
            {
                return "NoFederationNumber";
            }
            else
            {
                return "CanCreate";
            }


        }
    }
}
