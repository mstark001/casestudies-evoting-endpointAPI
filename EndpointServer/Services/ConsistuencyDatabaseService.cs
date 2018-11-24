using System;
using EndpointServer.Models;

namespace EndpointServer.Services
{
    public class ConsistuencyDatabaseService
    {
        private DatabaseService _db;

        //Default Constructor
        public ConsistuencyDatabaseService() : this(new DatabaseService()) { }
        //Dependency Injection Constructor
        public ConsistuencyDatabaseService(DatabaseService db)
        {
            _db = db;
        }


        public bool ValidateCredentails(string postcode, GeoCoordinate coord, string votingCode)
        {
            //Valide all this infromation makes sense with each other, and the current ,location isn't too far
            //the user should be registered for only a single consisteuency in this system
            _db.Connect();

            var consituency = _db.GetConsistuencyFromUserCode(votingCode);
            

            _db.Discoonect();
            return true;
        }
    }
}
