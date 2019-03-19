var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));
var expect = chai.expect;

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
// describe("Testing User Read Endpoints", function() {
//   describe("User has been Found", function() {
//     it("Is an existing user", async function() {

//       await axios
//         .get(BASEURL + "/users/5c79a6b19fa4f02121a74fd1")
//         .then(res => {
//           expect(res.status).to.equal(200);
//         })
//         .catch(res => {
//           chai.assert.fail("Unexpected response");
//         });
//     });
//   });
// });

// //Fail
// describe("Testing invalid Login Endpoints", function() {
//   describe("User not found", function() {
//     it("Is a not an existing user", async function() {

//       await axios
//         .get(BASEURL + "/users/someinvalidusercode")

//         .catch(res => {
//           expect(res.status).to.equal(500);
//         });
//     });
//   });
// });
