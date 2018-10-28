const contatosViewModel = {
    contatos: []
};

$.ajax({
    url: "/mensageiro/contatos"
})
    .then(function (response) {
        contatosViewModel.contatos = response;
        ko.applyBindings(contatosViewModel);
    })
    .catch(function () { /*Tratamento do erro;*/ });