$(document).ready(function () {
    var modal = document.getElementById("createModal");

    $("#create").on('click', function (e) {
        // Get the modal
        modal.style.display = "block";

    });

    // When the user clicks on <span> (x), close the modal
    $("#close").on('click', function () {
        modal.style.display = "none";
    });
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
});

