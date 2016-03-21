var connectToSQLDB = function () {
    PPWorkArea.webservices.SQLDatabaseServices.ConnectToSQLDB(sqlCallbackFunction);
    //PPWorkArea.webservices.SQLDatabaseServices.HelloWorld(sqlCallbackFunction);
    //SQLDataBase.webservices.SQLDatabaseServices.HelloWorld(sqlCallbackFunction);
};

function sqlCallbackFunction(input) {
    alert("SQL Connection executed - " + input);
}
