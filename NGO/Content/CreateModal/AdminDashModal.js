$(document).ready(function () {
    var modal = document.getElementById("createModal");

    $(".assign").on('click', function (e) {
        // Get the modal
        modal.style.display = "block";
        //console.log($(this).attr("id"));
        $("#requestId").attr("value", $(this).attr("id"));
    });

    // When the user clicks on <span> (x), close the modal
    $("#close").on('click', function () {
        modal.style.display = "none";
        $("#requestId").attr("value", "");
    });
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
            $("#requestId").attr("value", "");
        }
    }

    //$("#assign").on('click', function () {
    //    $("#requestId").val("");
    //});
});

