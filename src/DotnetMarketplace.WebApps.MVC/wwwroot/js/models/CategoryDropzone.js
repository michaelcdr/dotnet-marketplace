class CategoryDropzone
{
    constructor(categoryObj, imagesEl)
    {
        this._imagesEl = imagesEl;
        this._categoryObj = categoryObj;
        this.init();
    }

    getImgsEls(){
        return $("#categories-img-card-container .card");
    }

    updateImgHidden()
    {
        //colocando nome do arquivo no input hidden para mandarmos ao servidor quando salvarmos.
        if (this.getImgsEls().length > 0)
            this._imagesEl.val(this.getImgsEls().first().data('name'));
    }

    initImgRemoveEvent()
    {
        let _self = this;
        $("#categories-img-card-container button.btn").unbind('click');
        $("#categories-img-card-container button.btn").click(function(){
            let el = $(this);
            let callback = function(){
                el.parent().parent().fadeOut(500, function(){
                    el.parent().parent().remove();
                    _self._categoryObj.dropzone.updateImgHidden();
                });
            };
            alertConfirm({
                title: "Atenção", 
                text: "Deseja remover a imagem?"
            }, callback);
        });
    }

    init()
    {
        let _self = this;
        //iniciando evento de exclusao de imagens...
        _self.initImgRemoveEvent();

        //iniciando plugin responsavel pelo upload de imagens...
        _self.dropzoneInstance = new Dropzone("div#upload-container", {
            url: "/admin/categoria/upload",
            maxFiles: 1,
            paramName: "images", 
            acceptedFiles: ".jpeg,.jpg,.png",
            dictDefaultMessage: "Arraste seu arquivos aqui, ou clique para fazer upload!",
            maxfilesexceeded: function(file) {
                this.removeAllFiles();
                this.addFile(file);
            },
            init: function() {
                this.on("complete",function(data){
                    //removendo elemento do conainer de uploads
                    let el = $("#upload-container .dz-preview");
                    el.fadeOut(300, function(){
                        el.remove();
                        
                        if ($("#upload-container .dz-preview").length === 0)
                            $("#upload-container").removeClass("dz-started");

                        _self.updateImgHidden();
                    });
                });
                this.on("addedfile", function(file) { 

                    $("#categories-img-card-container").empty();
                });
                this.on("success", function(file) { 
                    //finalizou o upload
                    alertSuccess({
                        title:"Sucesso", 
                        text: "Sua imagem foi enviada para o servidor com sucesso."
                    });
                    
                    //adicionando arquivo adicionado no DOM...
                    $("#categories-img-card-container").append(
                        categoryImageCard.build({
                            fileName: file.name,
                            categoryId: $('#form-cadastro #categoryId').val(),
                            productImageId: null
                        })
                    );
                    
                    //reaplicando eventos de remoção de imagem...
                    _self.initImgRemoveEvent();
                });
            }
        });
    }
}