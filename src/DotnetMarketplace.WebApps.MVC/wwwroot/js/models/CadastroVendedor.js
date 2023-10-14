class CadastroVendedor{
    constructor(){
        this.tipoPessoaEl = $('input[name=tipo-pessoa]');
        this.btnSubmit = $('button#btn-salvar');
        this.iniciarEventos();
    }

    iniciarEventos(){
        let _self = this;

        _self.mascararCep();
        _self.mascararCnpj();
        _self.mascararCpf();
        _self.mascararDataNascimento();
        //console.log(_self);
        //console.log(_self.tipoPessoaEl);

        _self.tipoPessoaEl.change((el) => {
            //console.log($(el.target).val());
            let target = $(el.target).val()
            if ($('input[name=tipo-pessoa]').is(':checked')){
                _self.btnSubmit.removeAttr('disabled');
                $(".pessoa-ct").addClass('hidden');
                $(".pessoa-ct[data-target='"+target+"']").removeClass('hidden');
                $(".pessoa-ct[data-target='camposComum']").removeClass('hidden');
            }
        });

        _self.btnSubmit.submit(() => {
            
        });
    }

    mascararCep(){
        $('#cep').mask('00000-000');
    }
    mascararCnpj(){
        $('#cnpj').mask('00.000.000/0000-00', {reverse: true});
    }
    mascararCpf(){
        $('#cpf').mask('000.000.000-00', {reverse: true});
    }
    mascararDataNascimento(){
        //$('#dataNascimento').mask('00/00/0000');
    }
}

window.cadastroVendedor = new CadastroVendedor();