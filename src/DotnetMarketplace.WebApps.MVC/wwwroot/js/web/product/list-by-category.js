$(function () {
    $('.categories-menu ul > li a').on('click', function (ev) {
        obterProdutos(ev);
    });
    openFirstSubCategory();
});

function openFirstSubCategory() {
    if ($('.categories-menu ul > li').length > 0)
        $('.categories-menu ul > li:first a').trigger('click');
}

function obterProdutos(el) {
    el = $(el.target);
    let subCategoryId = parseInt(el.data('id'));
    let containerEl = $("#products-list");
    el.off('click');
    containerEl.html(getLoader('Processando, aguarde'));
    $.get("/produto/subcategoria", { subCategoryId: subCategoryId }, function (data) {
        containerEl.html(data);
        containerEl.find('.card').addClass('in');

        $("#qtd-produtos").html(containerEl.find('.card').length);
        el.on('click', obterProdutos);
    });
}