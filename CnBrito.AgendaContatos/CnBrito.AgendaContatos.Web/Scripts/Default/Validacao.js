
var validacao = {

    campoNulo: function (value, fieldErro) {
        if (value === null || value === undefined || value === "") {
            $(fieldErro).html("Preenchimento obrigatório!");
            return true;
        }

        $(fieldErro).html("");
        return false;
    },

    maxLenght: function (value, fieldErro, count, msg) {
        if (validacao.campoNulo(value, fieldErro))
            return true;

        if (value.length > count) {

            if (msg === null || msg === "" || msg === undefined) {
                msg = "O máximo de caracteres permitidos é " + count + " !";
            }

            $(fieldErro).html(msg);
            return true;
        }
        return false;
    },

    minLenght: function (value, fieldErro, count, msg) {
        if (validacao.campoNulo(value, fieldErro))
            return true;

        if (value.length < count) {

            if (msg === null || msg === "" || msg === undefined) {
                msg = "O mínimo de caracteres deve ser de " + count + " !";
            }

            $(fieldErro).html(msg);
            return true;
        }
        else {
            $(fieldErro).html("");
            return false;
        }
    },

    minLenghtTelefone: function (value, fieldErro, count) {
        if (validacao.campoNulo(value, fieldErro))
            return true;

        if (value.length < count) {
            $(fieldErro).html("Número de telefone inválido!");
            return true;
        }
        else {
            $(fieldErro).html("");
            return false;
        }
    },

    minLenghTelefoneOpcional: function (value, fieldErro, count) {

        if (value.length > 0) {
            if (value.length < count) {
                $(fieldErro).html("Número de telefone inválido!");
                return true;
            }
            else {
                $(fieldErro).html("");
                return false;
            }
        }
        else {
            $(fieldErro).html("");
            return false;
        }
    },

    minLenghCampoOpcional: function (value, fieldErro, count) {
        
        if (value.length > 0) {
            if (value.length < count) {
                $(fieldErro).html("O mínimo de caracter(es) deve ser de " + count + " !");
                return true;
            }
            else {
                $(fieldErro).html("");
                return false;
            }
        }
        else {
            $(fieldErro).html("");
            return false;
        }
    },

    maxLenghtCampoOpcional: function (value, fieldErro, count) {

        if (value.length > count) {            
            $(fieldErro).html("O máximo de caracter(es) permitido(s) é " + count + " !");
            return true;
        }
        return false;
    },

    noNumber: function (value, fieldErro) {
        if (typeof value === "number") {
            $(fieldErro).html("Valor não é númerico!");
            return true;
        }

        $(fieldErro).html("");
        return false;
    },
    
    selectSelecionado: function (value, fieldErro, msg) {
        if (parseInt(value) === 0 || value === "") {
            $(fieldErro).html(msg);
            return true;
        }

        $(fieldErro).html("");
        return false;
    },

    rangeSelecionadoInt: function (value, fieldErro, start, end) {
        if (validacao.campoNulo(value, fieldErro))
            return true;

        if (validacao.noNumber(value, fieldErro))
            return true;

        if (parseInt(value) < start && parseInt(end)) {
            $(fieldErro).val("valor fora do intervalo de " + start + " - " + end);
            return true;
        }

        $(fieldErro).html("");
        return false;
    },

    confirmaSenhas: function (senha1, fieldErro1, senha2, fieldErro2) {

        if (senha1 !== senha2) {
            //$(fieldErro1).html("Valor não é númerico!");
            $(fieldErro2).html("As senhas não conferem!");
            return true;
        }

        //$(fieldErro1).html("");
        $(fieldErro2).html("");
        return false;
    },

    /*
     Criar uma validação baseada numa expressão regexr
     @param {} value 
     @param {} fielderro 
     @param {} expression 
     @param {} mensagemErro 
     @returns {} 
     */
    validacaoRegExr: function (value, fieldErro, expression, mensagemErro) {
        if (value.search(expression) !== -1) {
            $(fieldErro).html("");
            return false;
        } else {
            $(fieldErro).html(mensagemErro);
            return true;
        }

    },

    ValidarEmail: function (value, fieldErro) {

        var email = value;
        if (email !== "") {
            var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (regex.test(email)) {
                return true;
            } else {
                $(fieldErro).html("Este endereço de email não é válido!");
                return false;
            }
        } 
    },

    errorAjax: function (jqXhr, textStatus, errorThrown) {

        
        var showLogOnConsole = true;

        if (jqXhr.responseJSON !== undefined && jqXhr.responseJSON !== null) {
            showLogOnConsole = false;
            console.log(jqXhr.responseJSON.mensagensRetorno.MensagemAnalise);
            swal({                
                title: "Atenção!",
                text: jqXhr.responseJSON.mensagensRetorno.MensagemExibicao,
                type: "warning",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (jqXhr.status === 0 || jqXhr.status === 408) {
            swal({
                title: "",
                text: "Faça login novamente ou verifique sua rede",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (jqXhr.status === 404) {
            swal({
                title: "",
                text: "Página solicitada não encontrada",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (jqXhr.status === 500) {
            swal({
                title: "",
                text: "Falha durante a requisição no projeto",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (jqXhr.status === 401.0 || jqXhr.status === 403) {
            swal({
                title: "",
                text: "Acesso negado ao Perfil para esta ação",
                type: "warning",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (textStatus === "parsererror") {
            swal({
                title: "",
                text: "Falha na análise JSON solicitada.",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (textStatus === "timeout") {
            swal({
                title: "",
                text: "Tempo limite da conexão foi excedido",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (textStatus === "abort") {
            swal({
                title: "",
                text: "Pedido Ajax abortado.",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else if (textStatus === "arquivo") {
            swal({
                title: "",
                text: "Não foi possível fazer upload desse arquivo.",
                type: "warning",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        } else {
            swal({
                title: "",
                text: "Erro não detectado: ",
                type: "error",
                confirmButtonColor: "#10386B",
                allowOutsideClick: false
            });
        }

        if (showLogOnConsole) {

            console.log('JqXhr; ');
            console.log(jqXhr);
            console.log('JqXhr ResponseText; ');
            console.log(jqXhr.responseText);
            console.log('Status; ');
            console.log(textStatus);
            console.log('Error; ');
            console.log(errorThrown);
        }

    }
};