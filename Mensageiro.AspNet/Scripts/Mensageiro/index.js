const contatosViewModel = {
    contatos: ko.observableArray() 
};

$.ajax({
    url: "/mensageiro/contatos"
})
    .then(function (response) {
        contatosViewModel.contatos(response);
        ko.applyBindings(contatosViewModel);
    })
    .catch(function (erro) { /*Tratamento do erro*/});