//document.querySelectorAll('.word').forEach(word => {
//    word.draggable = true;

//    word.addEventListener('dragstart', (e) => {
//        e.dataTransfer.setData('text/plain', word.textContent);
//    });
//});

//document.querySelectorAll('.drop-zone').forEach(zone => {
//    zone.addEventListener('dragover', (e) => {
//        e.preventDefault();
//    });

//    zone.addEventListener('drop', (e) => {
//        e.preventDefault();
//        const text = e.dataTransfer.getData('text/plain');
//        const correctAnswer = zone.parentElement.getAttribute('data-answer');

//        if (text === correctAnswer) {
//            zone.textContent = text;
//            zone.classList.add('correct');
//            zone.classList.remove('incorrect');
//        } else {
//            zone.textContent = text;
//            zone.classList.add('incorrect');
//            zone.classList.remove('correct');
//        }
//    });
//});

// Для каждого элемента с классом .word
document.querySelectorAll('.word').forEach(word => {
    word.addEventListener('dragstart', function (e) {
        // Передаем текст слова, чтобы использовать его в зоне сброса
        e.dataTransfer.setData('text/plain', word.textContent);
        word.classList.add('dragging'); // Добавляем стиль для перетаскивания
    });

    word.addEventListener('dragend', function (e) {
        word.classList.remove('dragging'); // Убираем стиль после окончания перетаскивания
    });
});

// Обработчики для зоны сброса (drop-zone)
document.querySelectorAll('.drop-zone').forEach(zone => {
    zone.addEventListener('dragover', function (e) {
        e.preventDefault(); // Разрешаем сброс элемента в эту зону
        zone.classList.add('hover'); // Подсвечиваем зону
    });

    zone.addEventListener('dragleave', function () {
        zone.classList.remove('hover'); // Убираем подсветку зоны, когда мышь покидает её
    });

    zone.addEventListener('drop', function (e) {
        e.preventDefault(); // Предотвращаем дефолтное поведение (например, открытие ссылки)

        const wordText = e.dataTransfer.getData('text/plain'); // Получаем текст перетаскиваемого слова
        const wordElement = document.querySelector(`.word:contains('${wordText}')`); // Находим элемент по тексту

        // Если элемент существует, выполняем дальнейшие действия
        if (wordElement) {
            wordElement.style.display = 'none'; // Скрываем слово из списка

            // Проверяем, соответствует ли слово правильному ответу для текущей зоны
            if (wordText === zone.closest('.question').getAttribute('data-answer')) {
                zone.textContent = wordText; // Устанавливаем текст в зону сброса
                zone.classList.add('correct'); // Добавляем стиль для правильного ответа
            } else {
                zone.textContent = wordText; // Устанавливаем текст в зону сброса
                zone.classList.add('incorrect'); // Добавляем стиль для неправильного ответа
            }

            // Обработчик для возвращения слова в список при двойном клике
            zone.addEventListener('dblclick', function () {
                zone.textContent = ''; // Очищаем зону
                zone.classList.remove('correct', 'incorrect'); // Убираем стили
                wordElement.style.display = 'inline-block'; // Возвращаем слово обратно в список
            });
        }

        zone.classList.remove('hover'); // Убираем подсветку зоны после завершения перетаскивания
    });
});