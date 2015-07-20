var xCoordinate = 0;
var yCoordinate = 0;
var differenceInX = 10;
var differenceInY = 10;

function initialize() {
    setInterval(bounceBall, 20);

}
function bounceBall() {
    var windowHeight = (window.innerHeight - 70);
    var windowWidth = (window.innerWidth - 70);

    xCoordinate += differenceInX;
    yCoordinate += differenceInY;
    var element = document.getElementById('ball');
    element.style.left = xCoordinate + "px";
    element.style.top = yCoordinate + "px";


    if (yCoordinate >= windowHeight) {
        differenceInY = -10;
        return;
    }
    if (xCoordinate >= windowWidth) {
        differenceInX = -10;
        return;
    }
    if (yCoordinate <= 0) {
        differenceInY = 10;
        return;
    }
    if (xCoordinate <= 0) {
        differenceInX = 10;
        return;
    }

}