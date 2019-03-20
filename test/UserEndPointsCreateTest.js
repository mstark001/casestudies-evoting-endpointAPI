var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));
var expect = chai.expect;


var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
describe("Testing Create User", function() {
  describe("Valid user created", function() {
    it("Is a valid user", async function() {
      var data = {
        postCode: "s25DL",
        firstName: "Shane",
        lastName: "Tandy",
        countryId: "UK",
        nationality: "British",
        dateOfBirth: "1997-01-08",
        fullAddress: "28, The Pinnacles"
      };

      await axios
        .post(BASEURL + "/users", data)
        .then(res => {
          expect(res.status).to.equal(200);
        })
        .catch(res => {
          chai.assert.fail("Unexpected response");
        });
    });
  });
});



//Fail
describe("Testing invalid create user", function() {
  describe("Invalid User created", function() {
    it("Is a not a valid user", async function() {
      
      //No data provided
      var data = {
      };

      await axios
        .post(BASEURL + "/users", data)
        .then(res => {
          chai.assert.fail("Unexpected success");
        })
        .catch(res => {
          expect(res.response.status).to.equal(500);
        });
    });
  });
});
