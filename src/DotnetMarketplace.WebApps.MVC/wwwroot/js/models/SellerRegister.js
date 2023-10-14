class SellerRegister
{
    constructor(){
        this._formEl = $('form#form-login');
        this._loginEl = $("#login");
        this._passwordEl = $("#password");
        this._nameEl = $("#nome");
        this._lastNameEl = $("#sobrenome");

        this.initEvents();
    }

    initEvents(){
        let _self = this;
        _self._formEl.submit(() => {
            _self.register();
            return false;
        });
    }

    validate()
    {
        let isValid = true;
        $('input[required]').each((index,el) => {
            if ($(el).val() === ''){
                $(el).addClass('is-invalid');
                isValid = false;
            }
        });
        return isValid;
    }

    getModel()
    {
        let _self = this;
        return {
            isValid : _self.validate(),
            model : {
                login : _self._loginEl.val(),
                password: _self._passwordEl.val(),
                lastName: _self._lastNameEl.val(),
                name: _self._nameEl.val(),
            }
        };
    }
    
    register()
    {
        let _self = this;
        let objModel = _self.getModel();
        let btn =_self._formEl.find('button');
        if (objModel.isValid){
            btn.button('loading');
            $.post('/vendedor-registrar-post', objModel.model, function(data){
                if (data.success){
                    alertConfirm({
                        text : data.msg,
                        type:'success',
                        title:'Sucesso',
                        showCancelButton: false,
                        confirmButtonColor: '#A5DC86',
                        confirmButtonText: 'Ok'
                    },() => {
                        document.location = "/admin/produto";
                    });
                } else {
                    alertError({ text: data.msg, toast : true, timer:4000 });
                    btn.button('reset');
                }
            }).fail(() => {
                alertServerError();
                btn.button('reset');
            });
        }
        return false;
    }
}
