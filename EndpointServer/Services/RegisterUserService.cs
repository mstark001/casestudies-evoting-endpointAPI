using System;
using EndpointServer.Models;

namespace EndpointServer.Services
{
    public class RegisterUserService
    {
        private DatabaseService _db;

        //Default Constructor
        public RegisterUserService() : this(new DatabaseService()) { }
        //Dependency Injection Constructor
        public RegisterUserService(DatabaseService db)
        {
            _db = db;
        }

        public void RegisterNewUser(User user)
        {
            _db.Connect();


            user.SetVotingCode(new Guid().ToString());
            user.SetRegisteredConsituency(_db.GetConsistuencyFromPostCode(user.GetPostcode()));

            _db.RecordNewUser(user);
            _db.Discoonect();
        }

        public void RegisterNewAnnoymousUser(byte[] form, string additionalDetails)
        {
            _db.Connect();
            _db.RecordNewAnnoymousRequestUser(form, additionalDetails);
            _db.Discoonect();
        }
    }
}
