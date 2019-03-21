
const userRoutes = require('./userRoutes');
const endpointRoutes = require('./endpointRoutes');


module.exports = function(app) {
  //Pass in the two different routes and set tem up using dependnecy injection
  userRoutes(app);
  endpointRoutes(app);
};