$(document).ready(function () {
    $('.popover-delete').popover();
    enableHover();
    $('.maskTime').inputmask('00:00:00', { reverse: true });






});




function enableHover() {
    $('.thumbnail').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
}

$(function () {





    $(document).on('show.bs.modal', '.modal', function () {
        var zIndex = 1040 + (10 * $('.modal:visible').length);
        $(this).css('z-index', zIndex);
        setTimeout(function () {
            $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
        }, 0);
    });



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





    $('body').on('click', '.modal-addAlbum', function (e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-addAlbum');
        $(this).attr('data-toggle', 'modal');
    });
    // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-addAlbum').modal('hide');
    });
    //clear modal cache, so that new content can be loaded
    $('#modal-addAlbum').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
    $('#CancelModal').on('click', function () {
        return false;
    });


});


$(".naner").click(function (event) {
        event.preventDefault();
        id = $(this).data("id");
        $.ajax({
            type: "get",
            datatype: "html",
            url: '/Artist/Details/' + id,
            success: function (result)
            {
                $('.artistName').html(result.artist.name);
                $("#btnAddAlbum").removeClass("hidden");
               // $("#btnAddAlbum").data("id", result.artist.ID);
                $("#btnAddAlbum").attr("href", "/Album/Create/" + result.artist.ID);
                

                $("#listAlbums").empty();
                $.each(result.albums.Data, function (index, element) {
                    var clone = $('#boxAlbum').clone().removeAttr("id");                  
                    clone.find('.albumTitle').html(element.name);
                    clone.find('a').attr("href", "/Album/Details/" + element.ID);
                    clone.removeClass("hidden");                    
                    clone.find('img').attr('src',  element.cover);
                    $("#listAlbums").append(clone);                    
                });
                enableHover();
            }
        });
       
    });






function getAlbums(id) 
{
    $.ajax({
        type: "get",
        datatype: "html",
        url: '/home/listAlbums/' + id,
        success: function (result) {
            // $('.artistName').html(result.artist.name);
            //  $("#btnAddAlbum").removeClass("hidden");
            // $("#btnAddAlbum").data("id", result.artist.ID);
            // $("#btnAddAlbum").attr("href", "/Album/Create/" + result.artist.ID);
            $("#listAlbums").html(result);

            // $("#listAlbums").empty();

            enableHover();
        }
    });
}


$(".naner2").click(function (event) {
    event.preventDefault();
    id = $(this).data("id");
    getAlbums(id);
    //$.ajax({
    //    type: "get",
    //    datatype: "html",
    //    url: '/home/listAlbums/' + id,
    //    success: function (result) {
    //       // $('.artistName').html(result.artist.name);
    //      //  $("#btnAddAlbum").removeClass("hidden");
    //        // $("#btnAddAlbum").data("id", result.artist.ID);
    //       // $("#btnAddAlbum").attr("href", "/Album/Create/" + result.artist.ID);
    //        $("#listAlbums").html(result);

    //       // $("#listAlbums").empty();

    //        enableHover();
    //    }
    //});

});



$(".addAlbumd").click(function (event) {
    event.preventDefault();
    id = $(this).data("id");
    $.ajax({
        type: "get",
        datatype: "html",
        url: '/Album/Create/' + id,
        success: function (result) {
            $('.artistName').html(result.artist.name);
            $("#btnAddAlbum").removeClass("hidden");
            $("#btnAddAlbum").data("id", result.artist.ID);
            $("#listAlbums").empty();
            $.each(result.albums.Data, function (index, element) {
                var clone = $('#boxAlbum').clone().removeAttr("id");
                clone.find('.albumTitle').html(element.name);
                clone.find('a').attr("href", "/Album/Details/" + element.ID);
                clone.removeClass("hidden");
                clone.find('img').attr('src', element.cover);
                $("#listAlbums").append(clone);
            });
            enableHover();
        }
    });

});