
var selectedPlayer;
var chanceCount;
function MarkerClicked(selectedMarker) {
    document.getElementById("start-button").disabled = false;
    document.getElementById("start-button").style.opacity = 1;
    document.getElementById("tick").style.visibility = "visible";
    if (selectedMarker === 1) {
        document.getElementById("selected").style.marginLeft = "70px";
        selectedPlayer = 1;
    } else {
        document.getElementById("selected").style.marginLeft = "230px";
        selectedPlayer = 2;
    }
}

function StartGame() {
    chanceCount = 0;
    var i, j;
    document.getElementById("first-screen").style.display = "none";
    document.getElementById("game-board").style.display = "block";
    for (i = 0; i < 3; i++) {
        document.getElementById("game-board").innerHTML += "<div>";
        for (j = 0; j < 3; j++) {
            document.getElementById("game-board").innerHTML += "<input onclick='MarkerPlaced(event)' type='button' id='block" + i + j + "'/>";
        }
        document.getElementById("game-board").innerHTML += "</div>";
    }
}

function MarkerPlaced(event) {
    event = event || window.event;
    event = event.target || event.srcElement;
    var block = event.id;
    document.getElementById(block).style.backgroundRepeat = "no-repeat";
    document.getElementById(block).value = selectedPlayer;
    document.getElementById(block).disabled = true;
    chanceCount++;
    if (selectedPlayer == 1) {
        document.getElementById(block).style.backgroundImage = "url('../images/x.png')";
        selectedPlayer = 2;
    } else {
        document.getElementById(block).style.backgroundImage = "url('../images/o.png')";
        selectedPlayer = 1;
    }
    if (chanceCount == 9) {
        if (checkWinningConditions(document.getElementById(block).value))
            setTimeout(function () { showResult(document.getElementById(block).value); }, 400);
        else
            setTimeout(function () { showResult('draw'); }, 400);
    }
    if (chanceCount > 4) {
        if (checkWinningConditions(document.getElementById(block).value))
            setTimeout(function () { showResult(document.getElementById(block).value); }, 400);
    }
  
}

function StartAgain() {
    document.getElementById("result-container").style.display = "none";
    document.getElementById("first-screen").style.display = "block";
    document.getElementById("tick").style.visibility = "hidden";
    document.getElementById("start-button").disabled = true;
    document.getElementById("start-button").style.opacity = .5;
}