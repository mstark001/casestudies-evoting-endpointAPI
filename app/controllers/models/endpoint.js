var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var endpointSchema = new Schema({

    // This schema is enforced by mongo to ensure our data is consitent
  url: {
      unique: true,
      required: true,
      type: String
  },
  name: {
      type: String,
  },
  countryCode: {
      required: true,
      type: String
  },
  postCodes: {
      required: true,
      type: [String]
  }

});


var Endpoint = mongoose.model('Endpoint', endpointSchema);

module.exports = Endpoint;