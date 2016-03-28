var loadfile = function () {
    alert("File loader");
};

var DisplayClientID = function () {
    PPWorkArea.webservices.WorkAreaWebServices.RetrieveClientID(clientID_CallbackSuccess);
};

function clientID_CallbackSuccess(value) {
    document.getElementById("tbxClientID").value = value;
}

var DisplaySecretID = function () {
    PPWorkArea.webservices.WorkAreaWebServices.RetrieveSecretID(secretID_CallbackSuccess)
};

function secretID_CallbackSuccess(value) {
    document.getElementById("tbxSecretID").value = value;
}
