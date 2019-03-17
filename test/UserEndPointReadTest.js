var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
describe("Testing User Read Endpoints", function() {
  describe("User has been Found", function() {
    it("Is an existing user", function() {
      var data = {
        postCode: "s14dg",
        userCode: "b3b34acfbd88b79e721ba26c4fe6646c799f91fd"
      };

      axios
        .get(BASEURL + "/users/5c79a6b19fa4f02121a74fd1", data)
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
  describe("User not found", function() {
    it("Is a not an existing user", function() {
      var data = {
        postCode: "invalidpostcode",
        userCode: "invalidusercode"
      };

      axios
        .get(BASEURL + "/users/5c79a6b19fa4f02121a74fd1", data)

        .catch(res => {
          expect(res.status).to.equal(500);
        });
    });
  });
});
