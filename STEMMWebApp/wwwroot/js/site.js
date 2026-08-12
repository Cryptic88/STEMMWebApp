document.addEventListener('DOMContentLoaded', function () {
    var toggleBtn = document.getElementById('sidebarToggle');
    var sidebar = document.getElementById('appSidebar');
    if (toggleBtn && sidebar) {
        toggleBtn.addEventListener('click', function () {
            sidebar.classList.toggle('collapsed');
        });
    }
});