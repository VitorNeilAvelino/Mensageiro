const contatosViewModel = {
    contatos: ko.observableArray(),
    exibirDestinatario: function (contato) {
        contatosViewModel.contatos().map(contato => contato.selecionado(false));
        contato.selecionado(true);

        destinatarioViewModel.destinatarioId = contato.usuarioId;
        destinatarioViewModel.destinatarioNome = contato.nome;
        destinatarioViewModel.conversaId = contato.conversaId;

        const destinatarioDiv = $("#destinatario")[0];
        ko.cleanNode(destinatarioDiv);
        ko.applyBindings(destinatarioViewModel, destinatarioDiv);

        const mensagemInput = $("#mensagem");
        mensagemInput.val("");
        mensagemInput.focus();

        mensagensViewModel.mensagens([]);
        obterConversa(contato.usuarioId);
    }
};

const destinatarioViewModel = {
    destinatarioNome: "",
    destinatarioId: "",
    conversaId: null
};

const mensagensViewModel = {
    mensagens: ko.observableArray()
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

function obterConversa(destinatarioId) {
    $.ajax({
        url: "/mensageiro/mensagens",
        data: { destinatarioId }
    })
        .then(function (response) {
            mensagensViewModel.mensagens(response);
            ko.applyBindings(mensagensViewModel, $("#conversation")[0]);
        });
}

$("#mensagemForm").submit(function (e) {
    const data = {
        mensagem: $("#mensagem").val(),
        conversaId: destinatarioViewModel.conversaId,
        remetenteId: usuarioId,
        destinatarioId: destinatarioViewModel.destinatarioId
    };

    $.ajax({
        type: "post",
        url: "/mensageiro/mensagens",
        data: data,
        success: function (response) {
            $("#mensagem").val("");
            obterConversa(data.destinatarioId);
            atualizarContatos();
        }
    });

    e.preventDefault();
});