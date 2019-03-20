var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));
var expect = chai.expect;

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
describe("Testing User Read", function() {
  describe("User has been Found", function() {
    it("Is an existing user", async function() {

      const headers = {
        headers: {
            "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
            "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
          }
      }
    
      await axios
        .get(BASEURL + "/users/5c916e0bb0b8f60019dae3b5", headers)
        .then(res => {
          expect(res.status).to.equal(200);
        })
        .catch(res => {
          chai.assert.fail("Unexpected response");
        });
    });
  });
});

//Forbidden due to no access token provided
describe("Testing Forbidden User Read ", function() {
  describe("User forbidden due to no access key", function() {
    it("User is forbidden", async function() {

      await axios
        .get(BASEURL + "/users/5c916e0bb0b8f60019dae3b5")
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
describe("Testing invalid user read", function() {
  describe("User not found", function() {
    it("Is a not an existing user", async function() {

      const headers = {
        headers: {
            "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
            "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
          }
      }

      await axios
        .get(BASEURL + "/users/someinvalidusercode", headers)
        .then(res => {
          chai.assert.fail("Unexpected success");
        })
        .catch(res => {
          expect(res.response.status).to.equal(500);
        });
    });
  });
});
