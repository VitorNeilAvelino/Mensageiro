const contatosViewModel = {
    contatos: ko.observableArray(),
    exibirDestinatario: function (contato) {
        contatosViewModel.contatos().map(contato => contato.selecionado(false));
        contato.selecionado(true);

        destinatarioViewModel.destinatarioId = contato.id;
        destinatarioViewModel.destinatarioNome = contato.nome;

        const destinatarioDiv = $("#destinatario")[0];
        ko.cleanNode(destinatarioDiv);
        ko.applyBindings(destinatarioViewModel, destinatarioDiv);
    }
};

const destinatarioViewModel = {
    destinatarioNome: "",
    destinatarioId: ""
};

atualizarContatos();

conectarUsuarioHub();

function atualizarContatos() {
    $.ajax({
        url: "/mensageiro/contatos"
    })
        .then(function (response) {
            response.map(contato => contato.selecionado = ko.observable(false));
            
            contatosViewModel.contatos(response);
            ko.applyBindings(contatosViewModel, $("#contatosDiv")[0]);
        })
        .catch(function (erro) { /*Tratamento do erro*/ });
}

function conectarUsuarioHub() {
    const connection = $.hubConnection();
    const hub = connection.createHubProxy("UsuarioHub");

    hub.on("atualizarContatos", atualizarContatos);

    connection.start();
}

//function obterConversa(remetente, destinatario) {
//    $.ajax({
//        url: "/mensageiro/conversas",
//        data: { remetente, destinatario }
//    })
//        .then(function (response) {
//            destinatarioViewModel = response;
//            ko.applyBindings(destinatarioViewModel);
//        })
//        .catch(function (erro) { /*Tratamento do erro*/ });
//}