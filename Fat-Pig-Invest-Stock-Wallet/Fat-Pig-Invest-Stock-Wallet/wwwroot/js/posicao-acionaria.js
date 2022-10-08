/* This javascript calls the partial view action from controller to
   get the data and relad the partial view */

var actionUrl = window.location.origin + '/Admin/pvPosicaoAcionaria';

$.ajax({
    url: actionUrl,
    type: 'POST',
    dataType: 'html',
    cache: false,
    success: function (html) {
        $('#divPvPosicaoAcionaria').html(html);
    }
});