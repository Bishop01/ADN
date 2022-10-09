$(document).ready(function () {

    $('#email').prop('readonly',true);

    $("#id").on('change paste input', function (e) {

        var text = $("#id").val();
        $('#email').val(text+"@student.aiub.edu");
    });

});