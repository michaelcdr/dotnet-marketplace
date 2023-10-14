
/*
* Classe responsável pela edição e criação de usuários.
*/
class UserForm
{
    constructor()
    {
        this.btnSubmit = $('button#btn-salvar');
        this.formEl = $("#formUsuario");
        this.btnAddAddress = $("#btn-add-address");
        this.initEvents();
        $("#name").focus();
    }
    
    validate()
    {
        let validateResponse = { isValid : true };
        let _self = this;
        _self.formEl.find('*[data-required="true"]').each((index, el) => {
            if ($(el).val() === '')
            {
                $(el).addClass('is-invalid');
                validateResponse.isValid = false;
            }
        });
        return validateResponse;
    }

    getModel()
    {
        let _self = this;
        return {
            userId:_self.formEl.find('#userId').val(),
            login:_self.formEl.find('#login').val(),
            password:_self.formEl.find('#password').val(),
            name:_self.formEl.find('#name').val(),
            role:_self.formEl.find('#role').val(),
            cpf:_self.formEl.find('#cpf').val(),
            lastName:_self.formEl.find('#lastName').val(),
            addresses:_self.getAddresses()
        };
    }

    getAddresses()
    {
        let addressesArray = [];
        $('.address-container').each(function(){
            addressesArray.push({
                cep : $(this).find("#cep").val(),
                street : $(this).find("#street").val(),
                neighborhood : $(this).find("#neighborhood").val(),
                stateId : $(this).find("#stateId").val(),
                city : $(this).find("#city").val(),
                complement : $(this).find("#complement").val()
            });
        });
        return addressesArray;
    }

    initEventRemoveAddress(){
        $('.btn-remover').unbind('click');
        $('.btn-remover').click(function(){
            $(this).parent().parent().parent().fadeOut(400,function() {
                $(this).remove();
            });
        });
    }

    initEvents()
    {
        let _self = this;
        $('#cpf').mask('000.000.000-00', {reverse: true});
        
        $('.cep').mask('00000-000', {reverse: true });
        
        _self.initEventRemoveAddress();

        _self.btnAddAddress.click(function(){
            $.get("/admin/endereco/cadastrar",function(data){
                $("#addresses-container").append(data);
                $('body,html').animate({
                    scrollTop: $(".address-container").last().offset().top
                }, 800,'swing',function(){

                    $(".address-container").last().find('#cep').focus();
                    _self.initEventRemoveAddress()
                    $('.cep').mask('00000-000', {reverse: true });
                });
            });
        })

        _self.formEl.submit(function() {
            let validateResponse = _self.validate();
            let model = _self.getModel();

            if (validateResponse.isValid){   
                //dados validos, iremos gravar...  
                let action = '/admin/usuario/cadastrar-post';

                //se tivermos um id no form sera uma atualização...
                if (model.userId && model.userId !== '')
                    action = '/admin/usuario/editar-post';
                
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
                    } else
                        alertError({ text:data.msg });

                }).fail(() => {
                    alertServerError();
                }); 
            }
            return false;
        });
    }
}

window.userForm = new UserForm();