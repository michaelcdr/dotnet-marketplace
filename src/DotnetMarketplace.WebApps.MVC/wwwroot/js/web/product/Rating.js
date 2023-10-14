class Ratting {
    constructor() {
        this.formEl = $('#form-rating');
        this.btnSubmit = $("#btn-rating");

        this._optionsSwalSuccess = {
            showCancelButton: false,
            type: 'success',
            confirmButtonText: 'Voltar para lista.',
            showLoaderOnConfirm: true,
            allowOutsideClick: false
        };
        this.initEvents();
    }

    initEvents() {
        let _self = this;

        _self.formEl.on('submit', function (ev, el) {
            let dados = {
                ProductId: parseInt($("#ProductId").val()),
                Rating: $('input[name=Rating]:checked').val(),
                Recommended: $('input[name=Recommended]:checked').val(),
                Title: $("#Title").val(),
                Description: $("#Description").val()
            };
            _self.btnSubmit.button('loading');
            $.post(_self.formEl.attr('action'), dados, function (data) {
                if (data.success) {
                    let optionsSwal = _self._optionsSwalSuccess;
                    optionsSwal.title = data.msg;
                    _self.resetFields();
                    Swal.fire(optionsSwal).then(function(){
                        window.location = "/detalhes-produto?id=" +$("#ProductId").val();
                    });
                } else {
                    alertServerError();
                    _self.btnSubmit.button('reset');
                }
            });
            return false;
        });
    }

    resetFields() {
        $('#Title, #Description').val("");
        $('#RatingExcelente').prop("checked", true);
        $('#RecommendedSim').prop("checked", true);
    }
}

window.rating = new Ratting();