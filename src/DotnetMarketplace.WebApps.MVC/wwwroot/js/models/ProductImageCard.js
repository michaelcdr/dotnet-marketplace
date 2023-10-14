class ProductImageCard {
    constructor() {

    }

    remove(fileName) {
        let el = $(`#product-img-cards-container .card[data-name="${fileName}"]`);

        el.fadeOut(300, () => {
            el.remove();
        });
    }

    build(fileObj) {
        return `<div class="card text-center" data-name="${fileObj.fileName}">
            <div class="text-center p-2">
                <img src="/assets/img/products/${fileObj.fileName}" 
                    style="max-width:100px; max-height:100px;"
                    class="img-fluid ">
            </div>
            <div class="card-footer p-2">
                <button type="button" class="btn btn-danger btn-sm" 
                    data-name="${fileObj.fileName}"
                    data-product-id="${fileObj.productId}" 
                    data-id="${fileObj.productImageId}" 
                    title="Remover imagem">
                    <i class="fa fa-trash"></i> Remover
                </button>
            </div>
        </div>`;
    }
}