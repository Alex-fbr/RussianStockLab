const fs = require('fs');

const FILE_NAME = './public/config.json';
const file = require('../public/config.json');

file.apiUrl = '{transform:risEditorWebApiUrl}/{transform:risEditorWebApiPath}/api';
file.routeBaseName = '/{transform:risEditorWebUIPath}/';

fs.writeFile(FILE_NAME, JSON.stringify(file), (err) => {
    if (err) return console.log(err);
    console.log(JSON.stringify(file));
});
