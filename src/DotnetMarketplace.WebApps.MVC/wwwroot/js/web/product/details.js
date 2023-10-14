$(function () {
    let qtdImgs = parseInt($("#img-container").data('qtd'));

    if (qtdImgs > 0) {
        let minImgs = 3;
        if (qtdImgs < minImgs)
            minImgs = qtdImgs;

        $('.slider-for').slick({
            arrows: false,
            fade: true,
            asNavFor: '.slider-nav-produto'
        });

        $('.similar-products-slider').slick({
            speed: 1500,
            slidesToShow: 3,
            slidesToScroll: 1,
            arrows: true,
            autoplay: true,
            infinite: true,
            autoplaySpeed: 2000,
            prevArrow: '<a class="slick-prev">' +
                '<i class="fa fa-chevron-left"></i>' +
                '</a>',
            nextArrow: '<a  class="slick-next">' +
                '<i class="fa fa-chevron-right"></i>' +
                '</a>'
        });

        $('.slider-nav-produto').slick({
            slidesToShow: minImgs,
            arrows: true,
            asNavFor: '.slider-for',
            focusOnSelect: true,
            prevArrow: '<a class="slick-prev arrow-slider-product-img-details">' +
                '<i class="fa fa-chevron-left"></i>' +
                '</a>',
            nextArrow: '<a class="slick-next arrow-slider-product-img-details">' +
                '<i class="fa fa-chevron-right"></i>' +
                '</a>'
        });
    }

    $('#btn-like').on('click', function () {
        let el = $(this);
        let isLiked = el.hasClass('fa-heart');
        let url = isLiked ? '/produto/descurtir' : '/produto/curtir';
        console.log(el);
        console.log(el.data('productId'));
        $.post(url, { productId: el.data('productId') }, function (data) {
            if (data.success) {
                if (isLiked)
                    el.removeClass('fa-heart').addClass('fa-heart-o');
                else
                    el.removeClass('fa-heart-o').addClass('fa-heart');
            }
        }).fail(function () {
            alertServerError();
        })
    });
});