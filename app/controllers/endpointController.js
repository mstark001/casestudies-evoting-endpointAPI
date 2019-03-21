var Endpoint = require('./models/endpoint');

var ObjectID = require('mongodb').ObjectID;
var db = null;



class EndpointController {

  // Create Endpoint, takes varaibles in the request
    createEndpoint(req, res){
      try
      {
        let endpoint = new Endpoint();
        endpoint.url = req.body.url;
        endpoint.countryCode = req.body.countryCode;
        endpoint.postCodes = req.body.postCodes;
        endpoint.name = req.body.name;

        Endpoint.create(endpoint.toJSON(), (err, out) => {
            if (err) { 
                res.status(500).send({ 'ERROR': 'An error has occurred '+err }); 
            } else {
                res.send(endpoint);
            }
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }

    //Gets the endpoint from the matching postcode and country
    getEndpoint(req, res){
      try
      {
        const countryId = req.params.countryId;
        const postCode = req.params.postCode;

        Endpoint.find({}, (err, out) => {
            if (err) {
                res.status(500).send({'ERROR':'An error has occurred '+err});
            } else {
                for (let i = 0; i < out.length; i++)
                {
                    if (out[i].postCodes.includes(postCode) &&
                    (out[i].countryCode === countryId))
                    {
                        //We found it!
                        res.send(out[i]);
                        return;
                    }
                }


                //We didn't find it
                //res.status(500).send({'ERROR':'An error has occurred and the required endpoint could not be found'});
                //if it doesn't exist, we assume north sheffield postcode
                res.send(out[0]);

            }
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }

    //get all endpoints
    getEndpoints(req, res){
      try
      {
        Endpoint.find({}, (err, out) => {
            if (err) {
              res.status(500).send({'ERROR':'An error has occurred '+err});
            } else {
              res.send(out);
            }
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }

    //updates the details of one endpoint
    updateEndpoint(req, res){
      try
      {
        const id = req.params.id;
        const idObject = { '_id': new ObjectID(id) };
      
    

        let endpoint = new Endpoint();
        endpoint._id = idObject;
        endpoint.url = req.body.url;
        endpoint.countryCode = req.body.countryCode;
        endpoint.postCodes = req.body.postCodes;
        endpoint.name = req.body.name;

      
        Endpoint.updateOne(idObject, endpoint.toJSON(), (err, out) => {
          if (err) {
              res.status(500).send({'ERROR':'An error has occurred '+err});
          } else {
              res.send(endpoint);
          } 
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }


//deletes an endpoint
    deleteEndpoint(req, res){
      try
      {
        const id = req.params.id;
        const idObject = { '_id': new ObjectID(id) };
        Endpoint.deleteOne(idObject, (err, out) => {
          if (err) {
            res.send({'ERROR':'An error has occurred '+err});
          } else {
            res.send(out + ' deleted');
          } 
        });
      }      
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }

}

module.exports = EndpointController;
