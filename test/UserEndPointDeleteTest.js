var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
// describe("Testing valid User Delete Endpoints", function() {
//   describe("User has been deleted", function() {
//     it("User deletion sucessful", function() {
//       var data = {
//         postCode: "s25dl",
//         firstName: "Shane",
//         lastName: "Tandy",
//         countryId: "UK",
//         nationality: "British",
//         dateOfBirth: "1997-01-08",
//         fullAddress: "28, The Pinnacles"
//       };

//       axios
//         .delete(BASEURL + "/users/5c8fb9de10e4dc0019fc760a", data)
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
// describe("Testing invalid user Delete Endpoints", function() {
//   describe("User has not been deleted", function() {
//     it("Nothing has been deleted", function() {
//       var data = {
//         postCode: "invalidpostcode",
//         userCode: "invalidusercode"
//       };

//       axios
//         .delete(BASEURL + "/users/5c8fb9de10e4dc0019fc760a", data)
//         .catch(res => {
//           expect(res.status).to.equal(500);
//         });
//     });
//   });
// });
