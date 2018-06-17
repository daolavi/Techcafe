var port = process.env.PORT || 3000,
    express = require('express'),
    path = require('path');

var app = express();

app.use('/static',express.static(path.join(__dirname,'static')));

app.get("*", (req, res) => res.sendFile('index.html', {root: __dirname}))

var server = app.listen(port, () => console.log('Listening at http://localhost:' + port));