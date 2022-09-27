const projects = ["project-1", "project-2", "project-3", "project-4"];
const projectStates = {
    "project-1": {
        currentSlide: 1,
        maxSlide: 2,
    },
    "project-2": {
        currentSlide: 1,
        maxSlide: 3,
    },
    "project-3": {
        currentSlide: 1,
        maxSlide: 3,
    },
    "project-4": {
        currentSlide: 1,
        maxSlide: 3,
    },
};

$(document).ready(function () {
    $('.prevSlide').click(function () {

        var id = $(this).parent().parent().attr("id");

        projects.map((project) => {
            if (project == id) {
                if (projectStates[id].currentSlide > 1) {
                    console.log("b");
                    var x = '#' + id;
                    var nextSlide = ".slide-" + (projectStates[id].currentSlide);

                    var prevSlide = ".slide-" + (projectStates[id].currentSlide);
                    projectStates[id].currentSlide -= 1;

                    $(x).children(prevSlide).hide("slide", { direction: "left" }, 800);
                    //$(x).children(prevSlide).hide();

                    //setTimeout(() => {
                    //    $(x).children(nextSlide).css("display", "none");
                    //}, 1000);
                }
            }
        });

    });

    $('.nextSlide').click(function () {

        var id = $(this).parent().parent().attr("id");

        projects.map((project) => {
            if (project == id) {
                if (projectStates[id].currentSlide < projectStates[id].maxSlide) {
                    console.log("a");
                    var x = '#' + id;
                    var prevSlide = ".slide-" + (projectStates[id].currentSlide);

                    projectStates[id].currentSlide += 1;
                    var nextSlide = ".slide-" + (projectStates[id].currentSlide);

                    $(x).children(nextSlide).show("slide", { direction: "left" }, 800);
                    //$(x).children(prevSlide).hide();
                    //setTimeout(() => {
                    //    $(x).children(prevSlide).css("display", "block");
                    //}, 1000);
                }
            }
        });

    });

});