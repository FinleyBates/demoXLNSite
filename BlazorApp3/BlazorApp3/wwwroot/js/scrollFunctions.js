window.scrollToBottom = function () {
    var messagesContainer = document.querySelector('.messages');
    messagesContainer.scrollTop = messagesContainer.scrollHeight;
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.output:nth-child(odd)').forEach(function (output, index) {
        output.style.setProperty('--index', index);
    });
});