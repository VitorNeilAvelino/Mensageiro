const contatosViewModel = {
    contatos: ko.observableArray()
};

atualizarContatos();

conectarUsuarioHub();

function atualizarContatos() {
    $.ajax({
        url: "/mensageiro/contatos"
    })
        .then(function (response) {
            contatosViewModel.contatos(response);
            ko.applyBindings(contatosViewModel);
        })
        .catch(function (erro) { /*Tratamento do erro*/ });
}

function conectarUsuarioHub() {
    const connection = $.hubConnection();
    const hub = connection.createHubProxy("UsuarioHub");

    hub.on("atualizarContatos", atualizarContatos);

    connection.start();
}