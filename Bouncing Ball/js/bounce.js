var axisX = 0;
var axisY = 0;
var dx = 10;
var dy = 10;

function initialize() {
    setInterval(bounceBall, 20);

}
function bounceBall() {
    var height = (window.innerHeight - 70);
    var width = (window.innerWidth - 70);

    axisX += dx;
    axisY += dy;
    var element = document.getElementById('ball');
    element.style.left = axisX + "px";
    element.style.top = axisY + "px";


    if (axisY >= height) {
        dy = -10;
        return;
    }
    if (axisX >= width) {
        dx = -10;
        return;
    }
    if (axisY <= 0) {
        dy = 10;
        return;
    }
    if (axisX <= 0) {
        dx = 10;
        return;
    }

}