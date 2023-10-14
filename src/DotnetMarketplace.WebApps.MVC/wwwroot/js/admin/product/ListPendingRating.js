class ListPendingRating {
    constructor() {
        this.initEvents();
        this._routeApproveRating = '/admin/produto/aprovar-avaliacao';
        this._routeList = '/admin/produto/lista-avaliacoes-pendentes-partial';
        this._listContainerEl = $('#container-products');

        console.log("entrou em");
    }

    initEvents() {
        let _self = this;
        $('.btn-approve').off('click')
        $('.btn-approve').on('click', function () {
            let btnEl = $(this);
            _self.approve(btnEl);
        });

        $('#btn-pesquisar').unbind('click')
        $('#btn-pesquisar').click(function () {
            let search = $("#search-products").val();
            _self.toList(0, search);
        });

        $("#search").unbind('keyup')
        $("#search").keyup(function (ev) {
            if (ev.which === 13)
                _self.toList(0, $("#search").val());
        });
    }

    approve(btnEl) {
        //exibindo msg amigavel ao usuario e quando ele confirmar volta para index
        let _self = this;
        let callback = function () {
            let params = { id: btnEl.data('id') };
            console.log(params);
            $.post(_self._routeApproveRating, params, function (data) {
                if (data.success) {
                    _self.toList(0, $("#search-products").val());
                } else {
                    alertError({ text: data.text, msg: data.msg });
                }
            });
        }
        alertConfirm({
            title: 'Deseja aprovar essa avaliação?',
            text: 'Essa ação não podera ser desfeita.',
            confirmButtonText: "Sim, desejo aprovar"
        }, callback);
    }

    toList(page, search) {
        let params = { page: page, s: search };
        let _self = this;
        $.get(_self._routeList, params, function (data) {
            _self._listContainerEl.html(data);
            _self.initEvents();
        });
    }
}

window.listPendingRating = new ListPendingRating();