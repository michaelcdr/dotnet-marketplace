class CategoryList {
    constructor() {
        this.initEvents();
        this._routeDelete = '/admin/categoria/deletar';
        this._routeList = '/admin/categoria/lista-table'
        this._listContainerEl = $("#list-container");
    }

    initEvents() {
        let _self = this;
        $('.btn-delete').unbind('click')
        $('.btn-delete').click(function () {
            let btnEl = $(this);
            _self.delete(btnEl);
        });

        $('#btn-pesquisar').unbind('click')
        $('#btn-pesquisar').click(function () {
            _self.toList(0, $("#search-categories").val());
        });

        $("#search-categories").unbind('keyup')
        $("#search-categories").keyup(function (ev) {
            if (ev.which === 13)
                _self.toList(0, $("#search-categories").val());
        });
    }

    delete(btnEl) {
        //exibindo msg amigavel ao usuario e quando ele confirmar volta para index
        let _self = this;
        let callback = function () {
            let params = { id: btnEl.data('id') };
            $.post(_self._routeDelete, params, function (data) {
                if (data.success) {
                    _self.toList(0, $("#search-categories").val());
                } else {
                    alertError({ text: data.text, msg: data.msg });
                }
            });
        }
        alertConfirm({
            title: 'Deseja remover essa categoria?',
            text: 'Ao fazer isso você estará removendo a categoria, essa ação não podera ser desfeita.'
        }, callback);
    }

    toList(page, search) {
        let params = { page: page, s: search };
        let _self = this;
        $.post(_self._routeList, params, function (data) {
            _self._listContainerEl.html(data)
            _self.initEvents();
        });
    }
}

window.categoryList = new CategoryList();