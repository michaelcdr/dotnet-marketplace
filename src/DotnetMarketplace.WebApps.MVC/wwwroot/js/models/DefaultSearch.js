class DefaultSearch {
    constructor() {
        this.animateSections();
    }

    animateSections() {
        //dando uma animada na bagaça...
        setTimeout(() => {
            $('.card').addClass('in');
        }, 300);
    }
}

window.pesquisaController = new DefaultSearch();