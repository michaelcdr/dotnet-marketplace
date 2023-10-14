//evitando que o dropzonejs fique procurando uma instancia...
Dropzone.autoDiscover = false;

class ProductCreate extends ProductCrudBase {
    constructor() {
        super();
        this.initEvents();
    }

    initEvents() {
        this.initSubmitEvent();
        this.initImgRemoveEvent();
        this.initAddAtributeEvent();
        this.initEventRemoveRowAttributeHtml();
        this.getCategories();
    }

    initSubmitEvent() {
        let _self = this;
        _self.formEl.submit('submit', function () {
            let validateResponse = _self.validator.validate();
            if (validateResponse.isValid) {
                //dados validos, iremos gravar...  
                _self.btnSubmit.button('loading');
                let dados = new FormData(this);
                let attributeValues = [];
                $('#tb-attributes tbody > tr').each(function () {
                    let el = $(this);
                    attributeValues.push({
                        attributeId: parseInt(el.data('attributeId')),
                        value: el.find('input').val()
                    });
                });
                dados.append('attributesValues', JSON.stringify(attributeValues));

                $.ajax({
                    type: 'POST',
                    url: '/admin/produto/cadastrar-post',
                    data: dados,
                    dataType: 'json',
                    contentType: false,
                    cache: false,
                    processData: false,
                    error: function () {
                        alertServerError();
                        _self.btnSubmit.button('reset');
                    },
                    success: function (data) {
                        if (data.success) {
                            let optionsSwal = _self._optionsSwalSuccess;
                            optionsSwal.title = data.msg;
                            Swal.fire(optionsSwal).then((result) => {
                                if (result.value)
                                    document.location = "/admin/produto";
                            });
                        } else {
                            alertError({ toast: false, text: data.msg });
                            _self.btnSubmit.button('reset');
                        }
                    }
                });
            }
            return false;
        });
    }
}

window.productImageCard = new ProductImageCard();
window.productCreate = new ProductCreate();