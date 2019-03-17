var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
describe("Testing Login Endpoints", function() {
  describe("Valid User Login", function() {
    it("Is a valid login", function() {
      var data = {
        postCode: "s14dg",
        userCode: "b3b34acfbd88b79e721ba26c4fe6646c799f91fd"
      };

      axios
        .post(BASEURL + "/users/login", data)
        .then(res => {
          expect(res.status).to.equal(200);
        })
        .catch(res => {
          chai.assert.fail("Unexpected response");
          console.log(res);
        });
    });
  });
});

//Fail
describe("Testing invalid Login Endpoints", function() {
  describe("Invalid User Login", function() {
    it("Is a not a valid login", function() {
      var data = {
        postCode: "",
        userCode: ""
      };

      axios
        .post(BASEURL + "/users/login", data)

        .catch(res => {
          expect(res.status).to.equal(500);
        });
    });
  });
});
