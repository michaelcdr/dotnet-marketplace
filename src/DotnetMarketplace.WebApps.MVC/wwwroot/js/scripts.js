window.carouselHome = new Carousel("#carrossel-home");
window.home = new Home();

function getLoader(msg) {
    return `<div class="text-center">
    <div class="spinner-border" role="status">
      <span class="sr-only"></span>
    </div><div class="loader-text">${msg}</div>
  </div>`;
}