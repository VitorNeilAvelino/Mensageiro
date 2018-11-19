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
            //ToDo: tratar horário em view-model na Aplicacao.
            response.map(contato => contato.dataUltimaMensagem !== null ?
                contato.dataUltimaMensagem = timeFormat(contato.dataUltimaMensagem) :
                null);

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
            response.map(mensagem => mensagem.ehDestinatario = mensagem.destinatarioId === usuarioId);
            response.map(mensagem => mensagem.horario = timeFormat(mensagem.horario));

            mensagensViewModel.mensagens(response);

            ko.applyBindings(mensagensViewModel, $("#conversation")[0]);
        })
        .catch(function (erro) { /*Tratamento do erro*/ });
}

$("#mensagemForm").submit(function (e) {
    const data = {
        mensagem: $("#mensagem").val(),
        conversaId: destinatarioViewModel.conversaId,
        remetenteId: usuarioId,
        destinatarioId: destinatarioViewModel.destinatarioId
    };

    $.ajax({
        type: "POST",
        url: "mensageiro/mensagens",
        data: data,
        success: function (response) {
            alert(data);
        }
    });

    e.preventDefault();
});

function timeFormat(dataString) {
    const data = new Date(dataString);

    hours = formatTwoDigits(data.getHours());
    minutes = formatTwoDigits(data.getMinutes());

    return hours + ":" + minutes;
}

function formatTwoDigits(n) {
    return n < 10 ? '0' + n : n;
}