using System;
namespace EndpointServer.Services
{
    public class OAuthDatabaseService
    {
        private DatabaseService _db;

        //Default Constructor
        public OAuthDatabaseService() : this(new DatabaseService()) { }
        //Dependency Injection Constructor
        public OAuthDatabaseService(DatabaseService db)
        {
            _db = db;
        }


        public bool VerifyOAuthCode(string oauth, string votingCode)
        {
            _db.Connect();
            //validate it somehow
            var dbOauth = _db.GetOAuthCodeFromUserCode(votingCode);

            _db.Discoonect();
            return dbOauth == oauth;
        }

        public string GetOAuthCode(string votingCode, string postcode)
        {
            _db.Connect();
            //generate and store record of the token somewhere - token is stored against voting code
            string oauth = "some token";
            _db.RegisterOAuthCodeAgainstUserCode(oauth, votingCode);

            _db.Discoonect();
            return oauth;
        }
    }
}
