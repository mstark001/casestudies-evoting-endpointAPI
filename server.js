//Setup

const express        = require('express');
const MongoClient    = require('mongodb').MongoClient;
const bodyParser     = require('body-parser');
const app            = express();

const db             = require('./config/db');

var mongoose = require('mongoose');

const port = process.env.OPENSHIFT_NODEJS_PORT || 8080
const ip_address = process.env.OPENSHIFT_NODEJS_IP || '127.0.0.1'
//const port = 8000;
//const ip_address = "";


app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, x-access-token, Content-Type, Accept");
    next();
  });
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());


mongoose.connect(db.url);
var connection = mongoose.connection;
connection.on('error', console.error.bind(console, 'connection error:'));
connection.once('open', function() {
    require('./app/routes')(app);
    app.listen(port, function(){
        console.log('Server started on ' + port + ' at ' + ip_address);
    });
});

    