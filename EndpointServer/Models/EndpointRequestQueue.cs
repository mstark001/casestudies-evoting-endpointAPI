using System;
using System.Collections.Generic;
using System.Linq;

namespace EndpointServer.Models
{
    public class EndpointRequestQueue : List<EndpointRequest>
    {
        //TODO MAKE THIS OBJECT THREAD SAFE FOR ACTUAL IMPLEMENTATION

        public EndpointRequest DequeueOrBlock()
        {
            while (this.Count == 0) {}
            //do nothing

            var resp = this.First();
            this.Remove(resp);

            return resp;
        }

        public void Enqueue(EndpointRequest req) 
        {
            this.Add(req);
        }



        #region Private Helper Functions



        #endregion 
    }
}
