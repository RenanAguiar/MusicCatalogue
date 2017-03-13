$(document).ready(function () {
    $('.popover-delete').popover();

    $('.thumbnail').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
});



$(function () {
    $('body').on('click', '.modal-master', function (e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-master');
        $(this).attr('data-toggle', 'modal');
    });
    // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-master').modal('hide');
    });
    $("#modal-master").on("show.bs.modal", function (e) {
        $('.popover-delete').popover();
    });
    //clear modal cache, so that new content can be loaded
    $('#modal-master').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
    $('#CancelModal').on('click', function () {
        return false;
    });







    $('body').on('click', '.modal-edit', function (e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-edit');
        $(this).attr('data-toggle', 'modal');
    });
    // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-edit').modal('hide');
    });
    //clear modal cache, so that new content can be loaded
    $('#modal-edit').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
    $('#CancelModal').on('click', function () {
        return false;
    });





});