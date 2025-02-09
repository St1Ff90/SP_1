function toggleMenu() {
    const menu = document.getElementById("dropdownMenu");
    menu.style.display = menu.style.display === "block" ? "none" : "block";
}

let currentSlide = 0;

function goToHomePage() {
    window.location.href = '/';
}

function toggleDropdown() {
    const dropdown = document.getElementById('dropdownMenu');
    dropdown.style.display = dropdown.style.display === 'block' ? 'none' : 'block';
}

function showSlide(index) {
    const slides = document.getElementById('slides');
    const totalSlides = slides.children.length;
    currentSlide = (index + totalSlides) % totalSlides;
    slides.style.transform = `translateX(-${currentSlide * 100}%)`;
}

function prevSlide() {
    showSlide(currentSlide - 1);
}

function nextSlide() {
    showSlide(currentSlide + 1);
}

function setRoleAndSubmit(role) {
    document.getElementById("role").value = role; // Устанавливаем значение роли
    document.forms[0].submit(); // Отправляем форму
}
function setAufgabeAndSubmit(vol) {
    document.getElementById("vol").value = vol; // Устанавливаем значение дейтвия
    document.forms[0].submit(); // Отправляем форму
}
// Автоматическая смена слайдов
setInterval(nextSlide, 5000);
