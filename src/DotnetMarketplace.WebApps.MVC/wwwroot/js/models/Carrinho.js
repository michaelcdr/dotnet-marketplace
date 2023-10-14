class Carrinho
{
    constructor()
    {
        this._routeDelete = "/remover-item-carrinho";
        this._routeList = "/listar-itens-carrinho";
        this._routeUpdateQtd = "/atualizar-quantidade-produto";
        this._carrinhoContainerEl = $("#carrinhos-itens");
        this.initEvents();
    } 
    
    initEvents()
    {
        let _self = this;
        $('.btn-delete').unbind('click')
        $('.btn-delete').click(function(){
            let btnEl = $(this);
            _self.delete(btnEl);
        });

        $('.qtd-product').unbind('change');
        $('.qtd-product').change(function(){
            //console.log($(this).val());
            let productId = $(this).data('productId');
            _self.updateQtd(productId, $(this).val(), $(this))
        });
    }
    
    
    delete(btnEl)
    {
        let _self = this;
        let callback = function(){       
            let params = { productId : btnEl.data('id') };
            $.post(_self._routeDelete, params, function(data){
                
                if (data.success){
                    _self.toList().then(() => {
                        _self.updateQtdNavOnlyDOM();
                        alertSuccess({ text:data.msg });
                    });
                } else {
                    alertError({ text: data.text , msg: data.msg });
                }
            });
        }

        alertConfirm(
            {
                title:'Deseja remover esse produto do carrinho?',
                text:'Essa ação não podera ser desfeita.'
            },
            callback
        );
    }

    toList()
    {
        let _self = this;
        return new Promise(function(resolve,reject){
            $.post(_self._routeList, function(data){
                _self._carrinhoContainerEl.html(data);
                _self.initEvents();
                resolve();
            });
        })
    }

    updateQtdNavOnlyDOM()
    {
        let qtd = 0;
        $("#carrinhos-itens tbody tr").each(function(){
            qtd += parseInt($(this).find('.qtd-product').val());
        });
        $("#form-pesquisa .badge").html(qtd);
        return qtd
    }

    updateQtd(productId, qtd, el)
    {
        let _self = this;
        if(qtd == 0){
            let params = { productId :productId };
            $.post(_self._routeDelete, params, function(data){
                
                if (data.success){
                    _self.toList().then(() => {
                        _self.updateQtdNavOnlyDOM();
                        alertSuccess({ text:data.msg });
                    });
                } else {
                    alertError({ text: data.text , msg: data.msg });
                }
            });
        } else{
            
            let request = { productId :productId, qtd:qtd };
            el.prop('disabled', true);
            $.post(_self._routeUpdateQtd, request, function(data){
                if (!data.success)
                {
                    //deixando a quantida maxima suportada...
                    alertError({
                        text:data.msg,
                        toast: true,
                        position: 'top-start',
                        showConfirmButton: false,                 
                        timer: 6000
                    });
                    el.val(data.currentQtd);
                } 
                else 
                {
                    $('#cart-sub-total').html(data.subTotal);
                    $('#cart-total').html(data.total);
                    $(`.product-price[data-product-id="${productId}"]`).html(`${data.finalValue}`);
                    _self.updateQtdNavOnlyDOM();
                    alertSuccess({ text:data.msg });
                }
                el.prop('disabled', false);
            }).fail(function(){
                alertServerError();
            });
        }
    }
}

window.carrinho = new Carrinho();