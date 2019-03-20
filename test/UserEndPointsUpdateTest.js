var axios = require("axios");
var chai = require("chai").use(require("chai-as-promised"));
var expect = chai.expect;

var BASEURL =
  "http://evoting-endpoint-evoting-endpoint.1d35.starter-us-east-1.openshiftapps.com";

//Pass
describe("Testing valid User Update", function() {
  describe("User has been Updated", function() {
    it("User update sucessful", async function() {
      var data = {
        postCode: "s25dl",
        firstName: "Shane",
        lastName: "Tandy",
        countryId: "UK",
        nationality: "British",
        dateOfBirth: "1997-01-08",
        fullAddress: "28, The Pinnacles"
      };

      const headers = {
        headers: {
            "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
            "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
          }
      }

      await axios
        .put(BASEURL + "/users/5c916e0bb0b8f60019dae3b5", data, headers)
        .then(res => {
          expect(res.status).to.equal(200);
        })
        .catch(res => {
          chai.assert.fail("Unexpected response");
        });
    });
  });
});

//Not authroised
describe("Testing not authroised User Update", function() {
  describe("User not updated due to lack of auth", function() {
    it("User update not succesful due to auth", async function() {
      var data = {
        postCode: "s25dl",
        firstName: "Shane",
        lastName: "Tandy",
        countryId: "UK",
        nationality: "British",
        dateOfBirth: "1997-01-08",
        fullAddress: "28, The Pinnacles"
      };

      await axios
        .put(BASEURL + "/users/5c8fb9de10e4dc0019fc760a", data)
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
describe("Testing invalid data for user Update", function() {
  describe("User has not been Updated with invalid data", function() {
    it("User has not been updated because data is invalid", async function() {
      
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
        .put(BASEURL + "/users/5c8fb9de10e4dc0019fc760a", data, headers)
        .then(res => {
          chai.assert.fail("Unexpected success");
        })
        .catch(res => {
          expect(res.response.status).to.equal(500);
        });
    });
  });
});

//Fail
describe("Testing invalid user Update", function() {
  describe("User has not been Updated", function() {
    it("User has not been updated because is was invalid", async function() {
      
      var data = {
        postCode: "s25dl",
        firstName: "Shane",
        lastName: "Tandy",
        countryId: "UK",
        nationality: "British",
        dateOfBirth: "1997-01-08",
        fullAddress: "28, The Pinnacles"
      };

      const headers = {
        headers: {
            "x-access-token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiZXhwZWN0ZWRFbmRwb2ludCI6Imh0dHA6Ly9ldm90aW5nLXZvdGluZzEtZXZvdGluZy1lbmRwb2ludC4xZDM1LnN0YXJ0ZXItdXMtZWFzdC0xLm9wZW5zaGlmdGFwcHMuY29tIiwiaWF0IjoxNTUyMTU5NzkxLCJleHAiOjEuMDAwMDAwMDAwMDAxNTUyM2UrMjF9.ZPWlLRAgPVOBMque6lVfPtLfQamySt2CB5MQRFC3CIo",
            "x-access-token2": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1Yzc5YTZiMTlmYTRmMDIxMjFhNzRmZDEiLCJmaXJzdE5hbWUiOiJNYXR0IiwibGFzdE5hbWUiOiJTdGFyayIsImlzQXVkaXRvciI6dHJ1ZSwicG9zdENvZGUiOiJzMTRkZyIsImNvdW50cnlJZCI6IlVLIiwibmF0aW9uYWxpdHkiOiJFbmdsaXNoIiwiZGF0ZU9mQmlydGgiOiIxOTk3LTAxLTA4VDAwOjAwOjAwLjAwMFoiLCJmdWxsQWRkcmVzcyI6IjI4IFBvcnRsYW5kIFRvd2VyLCA4IFBvcnRsYW5kIExhbmUsIFNoZWZmaWVsZCwgUzEgNERHIiwiaWF0IjoxNTUyODM5MTg4LCJleHAiOjEuMDAwMDAwMDAwMDAxNTUzZSsyMX0.mInaqw94O8yoPIFy9Jsfg9wydidGgACLC7aBsoXScIg",
          }
      }

      await axios
        .put(BASEURL + "/users/wrongid", data, headers)
        .then(res => {
          chai.assert.fail("Unexpected success");
        })
        .catch(res => {
          expect(res.response.status).to.equal(500);
        });
    });
  });
});
