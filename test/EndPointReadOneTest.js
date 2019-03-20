var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));
var expect = chai.expect;

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
describe("Testing one endpoint can be read", function() {
  describe("endpoint has been found", function() {
    it("Is an existing endpoint", async function() {

      const headers = {
        headers: {
            "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
            "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
          }
      }

      await axios
        .get(BASEURL + "/endpoint/UK/s14dg", headers)
        .then(res => {
          expect(res.status).to.equal(200);
        })
        .catch(res => {
          chai.assert.fail("Unexpected response");
        });
    });
  });
});

//Not authenticated

describe("Testing auth one endpoint can be read", function() {
  describe("endpoint has been denied", function() {
    it("blocked due to auth", async function() {

      await axios
        .get(BASEURL + "/endpoint/UK/s14dg")
        .then(res => {
          chai.assert.fail("Unexpected response");
        })
        .catch(res => {
          expect(res.response.status).to.equal(403);
        });
    });
  });
});

