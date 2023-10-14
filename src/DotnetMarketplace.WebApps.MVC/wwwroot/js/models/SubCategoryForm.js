/*
* Classe responsável pela edição e criação de categorias.
*/
class SubCategoryForm {
    constructor() {
        this.btnSubmit = $('button#btn-salvar');
        this.formEl = $("#form-cadastro");
        this.initEvents();
        $("#name").on('focus');
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
            categoryId: _self.formEl.find('#categoryId').val(),
            subCategoryId: _self.formEl.find('#subCategoryId').val(),
            title: _self.formEl.find('#title').val()
        };
    }

    initEvents() {
        let _self = this;
        _self.formEl.on('submit', function () {
            let validateResponse = _self.validate();
            let model = _self.getModel();

            if (validateResponse.isValid) {
                let action = _self.formEl.attr("action");
                $.post(action, model, function (data) {

                    if (data.success) {
                        Swal.fire({
                            title: data.msg,
                            showCancelButton: false,
                            type: 'success',
                            confirmButtonText: 'Voltar para lista.',
                            showLoaderOnConfirm: true,
                            allowOutsideClick: false

                        }).then((result) => {
                            if (result.value)
                                document.location = "/admin/subcategoria?id=" + _self.formEl.find('#categoryId').val();
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
window.subCategoryForm = new SubCategoryForm();