const usuariosViewModel = {
    usuarios: [
        { nome: 'Sílvia', id: 1927, ultimaMensagem: { horario: '19:57', conteudo: 'Olá!' } },
        { nome: 'Chu', id: 1931, ultimaMensagem: { horario: '19:58', conteudo: 'Oi!' } }]
};

ko.applyBindings(usuariosViewModel);