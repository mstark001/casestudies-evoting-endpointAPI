var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));
var expect = chai.expect;

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
// describe("Testing the endpoints can be created", function() {
//   describe("Endpoint has been created", function() {
//     it("Is an valid endpoint", async function() {
//       var data = {
//         countryCode: "UK",
//         postCodes: ["SY43PQ"],
//         name: "Shrewsbury",
//         url: "google.com"
//       };

//       const headers = {
//         headers: {
//             "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
//             "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
//           }
//       }

//       await axios
//         .post(BASEURL + "/endpoint", data, headers)
//         .then(res => {
//           expect(res.status).to.equal(200);
//         })
//         .catch(res => {
//           console.log(res);
//           chai.assert.fail("Unexpected response");
//         });
//     });
//   });
// });

//Not authorised
describe("Not authorised creation", function() {
  describe("Creation not authorised", function() {
    it("Is not authorised to do this", async function() {
      var data = {
        countryCode: "UK",
        postCodes: ["SY43PQ"],
        name: "Shrewsbury",
        url: "google.com"
      };

      await axios
        .post(BASEURL + "/endpoint", data)
        .then(res => {
          chai.assert.fail("Unexpected response");
        })
        .catch(res => {
          expect(res.response.status).to.equal(403);
        });
    });
  });
});


//Fail
describe("Testing invalid endpoints creation", function() {
  describe("Endpoint not created", function() {
    it("Is a not an valid endpoint creation", async function() {
      
      //Invalid data sent
      var data = {
      };

      const headers = {
        headers: {
            "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
            "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
          }
      }

      await axios
        .post(BASEURL + "/endpoint", data, headers)
        .then(res => {
          chai.assert.fail("Unexpected success");
        })
        .catch(res => {
          expect(res.response.status).to.equal(500);
        });
    });
  });
});
