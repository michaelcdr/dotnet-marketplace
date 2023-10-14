/*
* Classe responsável pela edição e criação de atributos.
*/
class AttributeForm {
    constructor() {
        this.btnSubmit = $('button#btn-salvar');
        this.formEl = $("#formAttributes");
        this.initEvents();
        $("#name").focus();
    }

    validate() {
        let validateResponse = { isValid: true };
        let _self = this;
        _self.formEl.find('*[data-required="true"]').each((index, el) => {
            if ($(el).val() === '') {
                $(el).addClass('is-invalid');
                validateResponse.isValid = false;
            }
        });
        return validateResponse;
    }

    getModel() {
        let _self = this;
        return {
            attributeId: _self.formEl.find('#attributeId').val(),
            name: _self.formEl.find('#name').val()
        };
    }

    initEvents() {
        let _self = this;

        _self.formEl.submit(function () {

            let validateResponse = _self.validate();
            let model = _self.getModel();

            if (validateResponse.isValid) {
                //dados validos, iremos gravar...  
                let action = _self.formEl.attr("action");
                $.post(action, model, function (data) {

                    if (data.success) {
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
                                document.location = "/admin/atributo";
                        });
                    } else
                        alertError({ text: data.msg });

                }).fail(() => {
                    alertServerError();
                });
            }
            return false;
        });
    }
}

window.attributeForm = new AttributeForm();