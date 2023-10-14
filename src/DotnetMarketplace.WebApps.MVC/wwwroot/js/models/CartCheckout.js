class CartCheckout 
{
    constructor()
    {
        this.btnSubmit = $('button#btn-save');
        this.formEl = $('#form-cadastro');
        this.validator = new GenericValidator($('#form-cadastro'));
        this.initEvents();
    }

    initEvents()
    {
        this.initSubmitEvent();
        this.mascararCep();
        this.mascararCpf();
        this.mascararDataNascimento();
        //this.seedForm();
    }
    mascararCep(){
        $('#cep').mask('00000-000');
    }
    mascararCpf(){
        $('#cpf').mask('000.000.000-00', {reverse: true});
    }
    mascararDataNascimento(){
        $('#dataNascimento').mask('00/00/0000');
    }
    seedForm(){
        $("#card-number").val("4556965669773172");
        $("#card-name").val("Michael C. Reis");
        $("#name").val("Michael Costa dos Reis");
        $("#cpf").val("000.000.000-00");
        $("#cep").val("00000-000");
        $("#card-expiration").val("01/1000");
        $("#cvv").val('123');
        $("#address").val('Rua Luiz Michelon');
        $("#neighborhood").val('Cruzeiro');
        $("#city").val('Caxias do Sul');
        $("#uf").find('option:eq(1)').attr('selected','selected');
        $("#complement").val('perto do Bar');
    }

    getModel(){
        return {
            name: $("#name").val(),
            dateOfBirth: $("#dateOfBirth").val(),
            lastName: $("#lastName").val(),
            cpf: $("#cpf").val(),
            cardNumber : $("#card-number").val(),
            cardName:$("#card-name").val(),
            cardExpiration:$("#card-expiration").val(),
            cvv:$("#cvv").val(),
            street:$("#street").val(),
            cep: $("#cep").val(),
            neighborhood:$("#neighborhood").val(),
            stateId:$("#stateId").val(),
            city:$("#city").val(),
            complement:$("#complement").val()
        };
    }

    initSubmitEvent()
    {
        let _self = this;
        _self.formEl.submit(function() {            
            let validateResponse = _self.validator.validate();
            if (validateResponse.isValid)
            {   
                //dados validos, iremos gravar...  
                _self.btnSubmit.button('loading');
                let formData = _self.getModel();
                $.post('/cart-checkout-post',formData, function(data){ 
                    if (data.success){
                        Swal.fire({
                            title: "Seu pedido foi criado com sucesso",     
                            text: data.msg,                       
                            showCancelButton: false,
                            type:'success',
                            confirmButtonText: 'Ok, voltar para lista.',
                            showLoaderOnConfirm: true,                        
                            allowOutsideClick: false

                        }).then((result) => {
                            if (result.value) {
                                document.location = "/";
                            }
                        });
                    } else {
                        //se deu alguma zica na request mostraremos 
                        //um alert amigavel...
                        alertServerError();
                        _self.btnSubmit.button('reset');
                    }
                });
            }
            return false;
        });
    }
}

window.cartCheckout = new CartCheckout();