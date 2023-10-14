class CategoryImageCard {
    constructor(path) {
        this.path = path;
    }

    remove(fileName) {
        let el = $(`#categories-img-card-container .card[data-name="${fileName}"]`);

        el.fadeOut(300, () => {
            el.remove();
        });
    }

    build(fileObj) {
        let _self = this;
        return `<div class="card text-center" data-name="${fileObj.fileName}">
            <div class="text-center p-2">
                <img src="${_self.path}${fileObj.fileName}" 
                    style="max-width:100px; max-height:100px;"
                    class="img-fluid ">
            </div>
            <div class="card-footer p-2">
                <button type="button" class="btn btn-danger btn-sm" 
                    data-name="${fileObj.fileName}" 
                    title="Remover imagem">
                    <i class="fa fa-trash"></i> Remover
                </button>
            </div>
        </div>`;
    }
}