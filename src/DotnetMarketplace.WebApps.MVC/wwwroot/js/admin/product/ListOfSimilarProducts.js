class ListOfSimilarProducts {
    constructor() {
        this.initEvents();
        this._routeDelete = '/admin/produto/similares/deletar';
        this._routeList = '/admin/produto/similares/lista-partial';
        this._listContainerEl = $('#container-products');
        this._similarProductsIds = [];
        this._productId = parseInt($("#productId").val());
        console.log("entrou em ListOfSimilarProducts");
    }

    initEvents() {
        let _self = this;
        $('.btn-delete').unbind('click')
        $('.btn-delete').click(function () {
            let btnEl = $(this);
            _self.delete(btnEl);
        });

        $('#btn-add').unbind('click')
        $('#btn-add').click(function () {
            _self.add($(this));
        });

        $('#btn-pesquisar').unbind('click')
        $('#btn-pesquisar').click(function () {
            let search = $("#search-products").val();
            _self.toList(0, search);
        });

        $("#search-products").unbind('keyup')
        $("#search-products").keyup(function (ev) {
            if (ev.which === 13)
                _self.toList(0, $("#search-products").val());
        });
    }

    delete(btnEl) {
        //exibindo msg amigavel ao usuario e quando ele confirmar volta para index
        let _self = this;
        let callback = function () {
            let params = { parentProductId: _self._productId, childProductId: btnEl.data('id') };
            $.post(_self._routeDelete, params, function (data) {
                if (data.success) {
                    _self.toList(0, $("#search-products").val());
                } else {
                    alertError({ text: data.text, msg: data.msg });
                }
            });
        }
        alertConfirm({
            title: 'Deseja remover esse produto?',
            text: 'Essa ação não podera ser desfeita.'
        }, callback);
    }

    toList(page, search) {
        let productId = this._productId;
        console.log(`carregando lista productId : ${productId}`);
        let params = { productId: productId, page: page, s: search };
        let _self = this;
        $.get(_self._routeList, params, function (data) {
            _self._listContainerEl.html(data);
            _self.initEvents();
        });
    }

    getProductsSelected() {
        let selectedProducts = [];
        $("#tb-products tbody tr input[type=checkbox]").each(function () {
            let el = $(this);
            if (el.is(":checked")) {
                selectedProducts.push(parseInt(el.val()));
            }
        });
        return selectedProducts;
    }

    addSimilarProduct(value) {
        let _self = this;
        let currentId = _self._similarProductsIds.find(id => id == parseInt(value));
        if (currentId === undefined) {
            console.log('valor não encontrado : ' + currentId);
            _self._similarProductsIds.push(parseInt(value));
        }
    }

    add(btnEl) {
        btnEl = $(btnEl);
        let _self = this;
        let productId = btnEl.data('productId');
        $.sidebar(this, {
            url: `/admin/produto/similares/add?id=${productId}`,
            callbackAbrir: function () {
                let container = $("#current-similar-products-container");
                _self._similarProductsIds = [];
                if (!$.isNullOrEmpty(container.find("#current-similar-products-ids").val())) {
                    _self._similarProductsIds = container.find("#current-similar-products-ids").val().split(",");
                    _self._similarProductsIds = _self._similarProductsIds.map(item => { return parseInt(item); });
                }

                $('[name=cb-similar-product]:checked').each(function () {
                    _self.addSimilarProduct($(this).val());
                });

                $('[name=cb-similar-product]').unbind('change');
                $('[name=cb-similar-product]').change(function () {
                    let value = $(this).val();
                    if ($(this).is(":checked")) {
                        _self.addSimilarProduct(value);
                    } else {
                        let similarProductsIdsAfterRemovingItem = _self._similarProductsIds.filter(function (item) {
                            return item != parseInt(value);
                        });
                        _self._similarProductsIds = similarProductsIdsAfterRemovingItem;
                    }
                });
            },
            botoes: [
                {
                    estilo: "btn-warning", icone: "fa fa-chevron-left", callback: function () {
                        $.sidebar.fnFechar();
                    }
                },
                {
                    estilo: "btn-dark", icone: "fa fa-save", label: "Salvar", callback: function () {
                        console.log('clicou em salvar');
                        let params = {
                            productId: productId,
                            similarProductsIds: _self._similarProductsIds
                        };
                        $.post('/admin/produto/similares/add-post', params, function (data) {
                            if (data.success) {
                                alertSuccess({ text: data.msg });
                                _self.toList(0, "");
                                $.sidebar.fnFechar();
                            } else
                                alertError({ text: data.msg });

                        }).fail(function () {
                            console.error("Não foi possível atualizar a lista de produtos similares.");
                        });
                    }
                }
            ]
        });
    }
}

window.productList = new ListOfSimilarProducts();