ko.extenders.scrollFollow = function (target, selector) {
    target.subscribe(function (newval) {
        var el = document.querySelector(selector);

        if (el.scrollTop === el.scrollHeight - el.clientHeight) {
            setTimeout(function () { el.scrollTop = el.scrollHeight - el.clientHeight; }, 0);
        }
    });

    return target;
};

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
    mensagens: ko.observableArray().extend({ scrollFollow: '#conversation' })
};

atualizarContatos();

conectarMensageiroHub();

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

function receberMensagem(remetenteId) {
    obterConversa(remetenteId);
    atualizarContatos();
}

function conectarMensageiroHub() {
    const connection = $.hubConnection();
    const hub = connection.createHubProxy("MensageiroHub");

    hub.on("atualizarContatos", atualizarContatos);
    hub.on("receberMensagem", receberMensagem);

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