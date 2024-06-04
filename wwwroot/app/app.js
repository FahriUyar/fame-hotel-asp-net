$('.slider').on('initialized.owl.carousel changed.owl.carousel', function (e) {
    if (!e.namespace) {
        return;
    }
    let carousel = e.relatedTarget;
    $('.slider-counter').text(carousel.relative(carousel.current()) + 1 + '/' + carousel.items().length);
}).owlCarousel({
    items: 1,
    loop: true,
    margin: 0,
    nav: true
});

$('.owl-carousel').owlCarousel({
    loop: true,
    margin: 50,
    nav: true,
    dots: true,
    autoplay: false,
    autoWidth: false,
    mouseDrag: true,
    smartSpeed: 1000,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 4
        }
    }
})

