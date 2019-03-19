var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
// describe("Testing all the endpoints can be read", function() {
//   describe("endpoint has been found", function() {
//     it("Is an existing endpoint", function() {
//       var data = {
//         _id: "5c79a95409546a212d2f6208",
//         countryCode: "UK"
//       };

//       axios
//         .get(BASEURL + "/endpoint")
//         .then(res => {
//           expect(res.status).to.equal(200);
//         })
//         .catch(res => {
//           chai.assert.fail("Unexpected response");
//           console.log(res);
//         });
//     });
//   });
// });

// //Fail
// describe("Testing invalid Endpoints", function() {
//   describe("Endpoint not found", function() {
//     it("Is a not an existing endpoint", function() {
//       var data = {
//         _id: "invalidid",
//         countryCode: "invalidcountrycode"
//       };

//       axios
//         .get(BASEURL + "/endpoint")

//         .catch(res => {
//           expect(res.status).to.equal(500);
//         });
//     });
//   });
// });
