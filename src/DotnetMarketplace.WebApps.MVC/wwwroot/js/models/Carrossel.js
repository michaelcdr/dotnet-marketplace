class Carousel{
    constructor(selector){
        //console.log('carrosel iniciado.');
        $(selector).slick({
            lazyLoad: 'ondemand',
            fade:true,
            autoplay:true,
            arrows:false,
            dots:true
        });
    }
}