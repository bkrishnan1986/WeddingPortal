function toggleSidebar() {
    if ($('body').hasClass('sidebar-collapse')) {
        $('body').removeClass('sidebar-collapse');
    } else {
        $('body').addClass('sidebar-collapse');
    }
};