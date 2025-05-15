using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceNDTOLayer;
using MySqlConnector;

namespace DAL
{
    public class PlayerData
    {
        public static async Task<bool> InsertPlayerAsync(string firstName, string lastName, bool gender, int federationNumber)
        {
            using var command = new MySqlCommand(@"
        INSERT INTO players (FirstName, LastName, Gender, FederationNumber)
        VALUES (@firstName, @lastName, @gender, @federationNumber)");

            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@gender", gender); 
            command.Parameters.AddWithValue("@federationNumber", federationNumber);

            int rowsAffected = await DatabaseManager.ExecuteAsync(command);
            return rowsAffected > 0;
        }

    }
}
