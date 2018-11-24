using System;
namespace EndpointServer.Services
{
    public class EndpointDatabaseService
    {
        private DatabaseService _db;

        //Default Constructor
        public EndpointDatabaseService() : this(new DatabaseService()) {}
        //Dependency Injection Constructor
        public EndpointDatabaseService(DatabaseService db)
        {
            _db = db;
        }

        public string GetEndpointFromUsercode(string votingCode)
        {
            _db.Connect();
            //query table for the right endpoint
            string resp = _db.GetEndpointFromUserCode(votingCode);
            _db.Discoonect();
            return resp;
        }
    }
}
