const usuariosViewModel = {
    usuarios: []
};

$.ajax({
    url: "/mensageiro/contatos"
}).done(function (response) {
    usuariosViewModel.usuarios = response;
    ko.applyBindings(usuariosViewModel);
});