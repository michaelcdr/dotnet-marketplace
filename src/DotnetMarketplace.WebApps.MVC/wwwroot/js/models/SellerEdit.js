
/*
* Classe responsável pela edição e de vendedores
*/
class SellerEdit
{
    constructor()
    {
        this.btnSubmit = $('button#btn-salvar');
        this.formEl = $("#form-cadastro");
        
        this.initEvents();
        $("#name").focus();
    }
    
    validate()
    {
        let _self = this;
        let validateResponse = { isValid : true };
        let validateContainer = function(selector){
            selector.find('*[data-required="true"]').each((index, el) => {
                if ($(el).val() === '') {
                    $(el).addClass('is-invalid');
                    validateResponse.isValid = false;
                }
            });   
        }
        validateContainer($('#container-dados-gerais'));
        validateContainer($('#container-local'));

        if ($("#cnpj").val() !== ""){
            validateContainer($('#container-pessoa-juridica'));
        } else {
            validateContainer($('#container-pessoa-fisica'));
        }
        
        return validateResponse;
    }

    getModel()
    {
        let _self = this;
        let model = {
            sellerId :_self.formEl.find('#sellerId').val(), 
            name:_self.formEl.find('#name').val(),
            email:_self.formEl.find('#email').val(),
            lastName:_self.formEl.find('#lastName').val(),
            website:_self.formEl.find('#website').val(),
            street:_self.formEl.find('#street').val(),
            neighborhood:_self.formEl.find('#neighborhood').val(),
            stateId:_self.formEl.find('#stateId').val(),
            city:_self.formEl.find('#city').val(),
            cep:_self.formEl.find('#cep').val(),
            complement:_self.formEl.find('#complement').val()
        };
        
        if (_self.formEl.find('#cpf').length > 0){
            model.cpf = _self.formEl.find('#cpf').val();
            model.age = _self.formEl.find('#age').val();
            model.dateOfBirth = _self.formEl.find('#dataNascimento').val();
        } else {
            model.company = _self.formEl.find('#company').val();
            model.fantasyName =_self.formEl.find('#nomeFantasia').val();
            model.cnpj = _self.formEl.find('#cnpj').val();
            model.branchOfActivity = _self.formEl.find('#branchOfActivity').val();
        }
        return model;
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
    

    initEvents()
    {
        let _self = this;

        _self.mascararCep();
        _self.mascararCnpj();
        _self.mascararCpf();

        _self.formEl.submit(function() {
            let validateResponse = _self.validate();
            let model = _self.getModel();

            if (validateResponse.isValid){   
                //dados validos, iremos gravar...  
                let action = _self.formEl.attr("action");
                
                $.post(action, model, function(data){
                    if (data.success){
                        //exibindo msg amigavel ao usuario e quando ele confirmar volta para index
                        Swal.fire({
                            title: data.msg,                            
                            showCancelButton: false,
                            type: 'success',
                            confirmButtonText: 'Voltar para lista.',
                            showLoaderOnConfirm: true,                        
                            allowOutsideClick: false

                        }).then((result) => {
                            if (result.value) 
                                document.location = data.urlDestino;
                        });
                    } else {
                        alertError({ title : data.msg });
                    }
                }).fail(() => {
                    alertServerError();
                }); 
            }
            return false;
        });
    }
}

window.sellerEdit = new SellerEdit();