var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
// describe("Testing the endpoints can be created", function() {
//   describe("Endpoint has been updated", function() {
//     it("Is an valid endpoint", function() {
//       var data = {
//         countryCode: "UK",
//         postCodes: "TF11AA",
//         name: "Telford"
//       };

//       axios
//         .put(BASEURL + "/endpoint/UK/sy43pq", data)
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
// describe("Testing invalid endpoints", function() {
//   describe("Endpoint not updated", function() {
//     it("Is a not an valid endpoint", function() {
//       var data = {
//         countryCode: "InvalidCountryCode",
//         postCodes: "invalidPostCode",
//         name: "invalidName000"
//       };

//       axios
//         .put(BASEURL + "/endpoint/UK/sy43pq", data)

//         .catch(res => {
//           expect(res.status).to.equal(500);
//         });
//     });
//   });
// });