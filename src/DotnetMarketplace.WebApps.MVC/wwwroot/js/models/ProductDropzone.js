class ProductDropzone
{
    constructor(productObj, imagesEl)
    {
        this._imagesEl = imagesEl;
        this._productObj = productObj;
        
        this.init();
    }

    update()
    {
        let arrayNames = [];
        $("#product-img-cards-container .card").each(function(){
            let fileName = $(this).data('name');
            arrayNames.push(fileName);
        })
        this._imagesEl.val(arrayNames.join('$$'));
    }

    init()
    {
        let _self = this;

        _self.dropzoneInstance = new Dropzone("div#upload-container", {
            url: "/admin/produto/upload",
            paramName: "images", 
            acceptedFiles: ".jpeg,.jpg,.png",
            dictDefaultMessage: "Arraste seus arquivos aqui, ou clique para fazer upload!",
            init: function() {
                this.on("complete",function(data){
                    //removendo elemento do conainer de uploads
                    let el = $("#upload-container .dz-preview");
                    el.fadeOut(300, function(){
                        el.remove();
                        
                        if ($("#upload-container .dz-preview").length === 0)
                            $("#upload-container").removeClass("dz-started");

                        _self.update();
                    });
                });

                this.on("success", function(file) { 
                    //finalizou o upload
                    alertSuccess({
                        title:"Sucesso", 
                        text: "Sua imagem foi enviada para o servidor com sucesso."
                    });
                    
                    //adicionando arquivo adicionado no DOM...
                    $("#product-img-cards-container").append(
                        productImageCard.build({
                            fileName: file.name,
                            productId: $('#form-cadastro #productId').val(),
                            productImageId: null
                        })
                    );
                    
                    //reaplicando eventos de remoção de imagem...
                    _self._productObj.initImgRemoveEvent();
                });
            }
        });
    }
}