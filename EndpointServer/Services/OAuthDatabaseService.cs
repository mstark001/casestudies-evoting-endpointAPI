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

        public bool VerifySignupOAuthCode(string oauth, string firstName, string lastName, string postcode)
        {
            _db.Connect();
            //validate it somehow
            var dbOauth = _db.GetRegisterRequestFromOAuth(oauth);

            _db.Discoonect();
            return dbOauth == oauth;
        }

        public string GetOAuthCode(string votingCode, string postcode)
        {
            _db.Connect();
            //generate and store record of the token somewhere - token is stored against voting code
            //these are stored against a user for verifcation durign the voting process, hecne the different oauth for registering
            string oauth = new Guid().ToString();
            _db.RegisterOAuthCodeAgainstUserCode(oauth, votingCode);

            _db.Discoonect();
            return oauth;
        }

        public string GetSignupOAuthCode(string firstName, string lastName, string postCode)
        {
            //these pamaters could be guids for an annon signup, so we will have to generate
            //a key to store them in a sign up database/session
            _db.Connect();
            string oauth = new Guid().ToString();
            _db.RegisterOAuthCodeAgainstSignUp(oauth, firstName, lastName, postCode);

            _db.Discoonect();
            return oauth;
        }
    }
}
