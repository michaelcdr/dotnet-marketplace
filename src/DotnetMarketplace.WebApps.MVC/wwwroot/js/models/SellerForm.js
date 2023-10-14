
/*
* Classe responsável pela edição e criação de usuários.
*/
class SellerForm
{
    constructor()
    {
        this.btnSubmit = $('button#btn-salvar');
        this.formEl = $("#form-cadastro");
        this.tipoPessoaEl = $('input[name=tipo-pessoa]');
        
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

        if ($("input[name=tipo-pessoa]:checked").val() === "fisica"){
            validateContainer($('#container-pessoa-fisica'));
        } else {
            validateContainer($('#container-pessoa-juridica'));
        }
        
        return validateResponse;
    }

    getModel()
    {
        let _self = this;
        return {
            userId:_self.formEl.find('#userId').val(),
            type: _self.formEl.find("input[name=tipo-pessoa]:checked").val(),
            login:_self.formEl.find('#login').val(),
            password:_self.formEl.find('#password').val(),
            name:_self.formEl.find('#name').val(),
            email:_self.formEl.find('#email').val(),
            lastName:_self.formEl.find('#lastName').val(),
            website:_self.formEl.find('#website').val(),

            cpf:_self.formEl.find('#cpf').val(),
            age:_self.formEl.find('#age').val(),
            dateOfBirth:_self.formEl.find('#dataNascimento').val(),

            street:_self.formEl.find('#street').val(),
            neighborhood:_self.formEl.find('#neighborhood').val(),
            stateId:_self.formEl.find('#stateId').val(),
            city:_self.formEl.find('#city').val(),
            cep:_self.formEl.find('#cep').val(),
            complement:_self.formEl.find('#complement').val(),

            company:_self.formEl.find('#company').val(),
            fantasyName:_self.formEl.find('#nomeFantasia').val(),
            cnpj:_self.formEl.find('#cnpj').val(),
            branchOfActivity:_self.formEl.find('#branchOfActivity').val()
        };
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

        $("input[name=tipo-pessoa]").change((el) => {
            if ($("input[name=tipo-pessoa]:checked").val() === "juridica"){
                $("#container-pessoa-juridica").removeClass('hidden');
                $("#container-pessoa-fisica").addClass('hidden');
            } else if($("input[name=tipo-pessoa]:checked").val() === "fisica"){
                $("#container-pessoa-fisica").removeClass('hidden');
                $("#container-pessoa-juridica").addClass('hidden');
            }
        });

        console.log(_self.formEl)
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
                                document.location = "/admin/vendedor";
                        });
                    } else {
                        console.log(data)
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

window.sellerForm = new SellerForm();