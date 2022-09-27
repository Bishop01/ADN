$(document).ready(function () {
    $('#card1').show("slide", { direction: "up" }, 800);
    $('#card2').show("slide", { direction: "down" }, 800);
    $('#card3').show("slide", { direction: "up" }, 800);

    $('#card1').mouseenter(function () {
       $(this).effect("shake", { times: 1 });;
    });
    $('#card2').mouseenter(function () {
        $(this).effect("shake", { times: 1 });;
    });
    $('#card3').mouseenter(function () {
        $(this).effect("shake", { times: 1 });;
    });

});