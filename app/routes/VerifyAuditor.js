var jwt = require('jsonwebtoken');
var config = require('../../config/enviromentVariables');

//This algorithim is middleware to only accept requests from auditor users
function verifyAudit(req, res, next) {
  var token = req.headers['x-access-token'];
  if (!token)
    return res.status(403).send({ auth: false, message: 'No token provided.' });
  jwt.verify(token, config.secret, function(err, decoded) {
    if (err)
    return res.status(500).send({ auth: false, message: 'Failed to authenticate token.' });

    //Everything good?
    if (!decoded.isAuditor)
    return res.status(403).send({ auth: false, message: 'No Auditor token provided.' });
    
    next();
  });
}

module.exports = verifyAudit;