document.addEventListener('DOMContentLoaded', function () {

    /* =========================================================
       THEME
       ========================================================= */

    var STORAGE_KEY = 'stemm-theme';

    function resolveTheme(pref) {
        if (pref === 'system') {
            return (
                window.matchMedia &&
                window.matchMedia('(prefers-color-scheme: light)').matches
            )
                ? 'light'
                : 'dark';
        }

        return pref;
    }

    function applyTheme(pref) {
        document.documentElement.setAttribute(
            'data-theme',
            resolveTheme(pref)
        );

        document.querySelectorAll('.theme-option').forEach(function (el) {
            el.classList.toggle(
                'selected',
                el.dataset.theme === pref
            );
        });
    }

    var current =
        localStorage.getItem(STORAGE_KEY) || 'dark';

    document.querySelectorAll('.theme-option').forEach(function (el) {

        el.classList.toggle(
            'selected',
            el.dataset.theme === current
        );

        el.addEventListener('click', function () {

            localStorage.setItem(
                STORAGE_KEY,
                el.dataset.theme
            );

            applyTheme(el.dataset.theme);
        });
    });

    if (window.matchMedia) {

        window
            .matchMedia('(prefers-color-scheme: light)')
            .addEventListener('change', function () {

                if (
                    (localStorage.getItem(STORAGE_KEY) || 'dark')
                    === 'system'
                ) {
                    applyTheme('system');
                }

            });
    }


    /* =========================================================
       SIDEBAR
       ========================================================= */

    var sidebarToggle =
        document.getElementById('sidebarToggle');

    var appShell =
        document.querySelector('.app-shell');

    var sidebar =
        document.getElementById('appSidebar');

    var sidebarIcon =
        sidebarToggle
            ? sidebarToggle.querySelector('i')
            : null;


    if (sidebarToggle && appShell && sidebar) {

        sidebarToggle.addEventListener('click', function () {

            appShell.classList.toggle('sidebar-collapsed');

            var collapsed =
                appShell.classList.contains('sidebar-collapsed');


            /* Change icon */

            if (sidebarIcon) {

                sidebarIcon.classList.remove('bi-list');
                sidebarIcon.classList.remove('bi-layout-sidebar');

                sidebarIcon.classList.add(
                    collapsed
                        ? 'bi-layout-sidebar-inset'
                        : 'bi-layout-sidebar'
                );
            }


            /* Update tooltip */

            sidebarToggle.setAttribute(
                'title',
                collapsed
                    ? 'Expand sidebar'
                    : 'Collapse sidebar'
            );


            /* Remember state */

            localStorage.setItem(
                'stemm-sidebar-collapsed',
                collapsed
            );

        });


        /* Restore sidebar state */

        var sidebarCollapsed =
            localStorage.getItem(
                'stemm-sidebar-collapsed'
            ) === 'true';


        if (sidebarCollapsed) {

            appShell.classList.add(
                'sidebar-collapsed'
            );

            if (sidebarIcon) {

                sidebarIcon.classList.remove('bi-list');
                sidebarIcon.classList.add(
                    'bi-layout-sidebar-inset'
                );
            }

            sidebarToggle.setAttribute(
                'title',
                'Expand sidebar'
            );
        }
    }

});