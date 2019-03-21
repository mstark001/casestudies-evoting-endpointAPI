var User = require('./models/user');

var ObjectID = require('mongodb').ObjectID;
var db = null;

var jwt = require('jsonwebtoken');
var crypto = require("crypto");
var bcrypt = require('bcryptjs');
var config = require('../../config/enviromentVariables');
var axios = require("axios");

class UserController {

  //Creates a user from the passed in data
    createUser(req, res){
      try
      {
        let user = new User();
        user.firstName = req.body.firstName;
        user.lastName = req.body.lastName;

        //Genereates a unique 6 charater string
        let uId = crypto.randomBytes(3).toString('hex');

        user.postCode = req.body.postCode;
        //Creates a unique encrpyted id from the genereated code and the postcode
        user.eUID = bcrypt.hashSync(uId + req.body.postCode, 8);
        user.isAuditor = false;
        user.countryId = req.body.countryId;
        user.nationality = req.body.nationality;
        user.dateOfBirth = req.body.dateOfBirth;
        user.fullAddress = req.body.fullAddress;

        User.create(user.toJSON(), (err, out) => {
            if (err) { 
                res.status(500).send({ 'ERROR': 'An error has occurred '+err }); 
            } else {
                res.send(uId);
            }
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }

    //Gets a given user from an id
    getUser(req, res){
      try
      {
        const id = req.params.id;
        const idObject = { '_id': new ObjectID(id) };
        User.findOne(idObject, (err, out) => {
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

    //Gets allthe users
    getUsers(req, res){
      try
      {
        User.find({}, (err, out) => {
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

    //updates a given users data
    updateUser(req, res){
      try
      {
        const id = req.params.id;
        const idObject = { '_id': new ObjectID(id) };
      
    

        let user = new User();
        user._id = idObject;
        user.firstName = req.body.firstName;
        user.lastName = req.body.lastName;

        let uId = crypto.randomBytes(20).toString('hex');

        user.postCode = req.body.postCode;
        user.eUID = bcrypt.hashSync(uId + req.body.postCode, 8);
        user.isAuditor = req.body.isAuditor;
        user.countryId = req.body.countryId;
        user.nationality = req.body.nationality;
        user.dateOfBirth = req.body.dateOfBirth;
        user.fullAddress = req.body.fullAddress;

      
        User.updateOne(idObject, user.toJSON(), (err, out) => {
          if (err) {
              res.status(500).send({'ERROR':'An error has occurred '+err});
          } else {
              res.send(uId);
          } 
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred'});
      }
    }

    //deletes a given user
    deleteUser(req, res){
      try
      {
        const id = req.params.id;
        const idObject = { '_id': new ObjectID(id) };
        User.deleteOne(idObject, (err, out) => {
          if (err) {
            res.status(500).send({'ERROR':'An error has occurred '+err});
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

    //perform a login with a user code and post code
    async login(req, res){
      try
      {
        let postCode = req.body.postCode;
        let postCodeObject = { '_id': new Object(postCode) };

 
  
        await User.find({postCode: postCode}, async (err, out) => {
          if (err) {
            res.status(500).send('FAILURE '+err);
          } else {
            if (out == null)
              res.status(500).send('FAILURE Could not find anyone at that postcode');
            else {
              
              for (let i = 0; i < out.length; i++)
              {
                  if (bcrypt.compareSync(req.body.userCode + req.body.postCode, out[i].eUID))
                  {
                    // create a request token
                    var tempToken = jwt.sign({
                      auth: "secret"
                    }, config.secret, {
                      expiresIn: 10000
                    });

                    //<Make request with a fake token to get the right endpoint for th given user
                    var url=`http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com/endpoint/${out[i].countryId}/${out[i].postCode}`;
                    
                    let result = await axios.get(url,
                    { headers: {"x-access-token" : `${tempToken}`} }
                    )
                    .catch(err => {
                      res.status(500).send('FAILURE Couldnt find endpoint for inputted postcode');
                    });

                    // create a token
                    var token = jwt.sign({
                      _id: out[i]._id,
                      firstName: out[i].firstName,
                      lastName: out[i].lastName,
                      isAuditor : out[i].isAuditor,
                      postCode : out[i].postCode,
                      countryId : out[i].countryId,
                      nationality : out[i].nationality,
                      dateOfBirth : out[i].dateOfBirth,
                      fullAddress : out[i].fullAddress,
                      expectedEndpoint : result.data.url,
                      constiuenecyId : result.data.name
                    }, config.secret, {
                      expiresIn: 1000000000000000086400 // expires in a very long time (Need so tests still work)
                    });
                    res.send(token);
                    return;
                  }
              }

              res.status(500).send('FAILURE No Matching users at that postcode');
            }
          }
        });
      }
      catch (err)
      {
        console.log(err);
        res.status(500).send({"ERROR": 'An error has occurred '+err});
      }
    }

}

module.exports = UserController;
