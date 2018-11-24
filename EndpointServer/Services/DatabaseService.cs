using System;
using EndpointServer.Interfaces;
using EndpointServer.Models;

namespace EndpointServer.Services
{
    public class DatabaseService : IDatabaseService
    {
        private string databaseAddress = "some address";

        //This should be maintained somehow through different requests
        private DatabaseConnection databaseConnection;

        public void Connect()
        {
            databaseConnection = new DatabaseConnection();

        }

        public void Discoonect()
        {
            databaseConnection.Close();
            databaseConnection = null;
        }



        public User GetUserFromUserCode(string votingCode)
        {
            return new User();
        }

        public string GetEndpointFromUserCode(string votingCode)
        {
            return "some endpoint";
        }

        public string GetOAuthCodeFromUserCode(string votingCode)
        {
            return "some oauthCode";
        }

        public string GetConsistuencyFromUserCode(string votingCode)
        {
            return "some code";
        }

        public void RegisterOAuthCodeAgainstUserCode(string oauth, string userCode)
        {
            //do a thing
        }


    }
}
