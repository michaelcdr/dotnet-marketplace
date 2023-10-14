class SubCategoryList {
    constructor() {
        this.initEvents();
        this._routeDelete = '/admin/subcategoria/deletar';
        this._routeList = '/admin/subcategoria/lista-table'
        this._listContainerEl = $("#list-container");
    }

    initEvents() {
        let _self = this;
        $('.btn-delete').unbind('click')
        $('.btn-delete').click(function () {
            _self.delete($(this));
        });

        $('#btn-pesquisar').unbind('click')
        $('#btn-pesquisar').click(function () {
            _self.toList(0, $("#search").val());
        });

        $("#search").unbind('keyup')
        $("#search").keyup(function (ev) {
            if (ev.which === 13)
                _self.toList(0, $("#search").val());
        });
    }

    delete(btnEl) {
        //exibindo msg amigavel ao usuario e quando ele confirmar volta para index
        let _self = this;
        let callback = function () {
            let params = { id: btnEl.data('id') };
            $.post(_self._routeDelete, params, function (data) {
                if (data.success) {
                    _self.toList(0, $("#search").val());
                } else {
                    alertError({ text: data.text, msg: data.msg });
                }
            });
        }
        alertConfirm({
            title: 'Deseja remover essa sub categoria?',
            text: 'Ao fazer isso você estará removendo a sub categoria, essa ação não podera ser desfeita.'
        }, callback);
    }

    toList(page, search) {
        let _self = this;
        let params = {
            subCategoryId: $("#subCategoryId").val(),
            categoryId: _self._listContainerEl.data('categoryId'),
            page: page, s: search
        };
        $.get(_self._routeList, params, function (data) {
            _self._listContainerEl.html(data)
            _self.initEvents();
        });
    }
}

window.subCategoryList = new SubCategoryList();