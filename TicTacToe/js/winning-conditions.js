function checkWinningConditions(currentMarker){
	if(horizontalCondition(currentMarker)==true)
		return true;
	else if(verticalCondition(currentMarker)==true)
		return true;
	else if(leftDiagonalCondition(currentMarker)==true)
		return true;
	else if(rightDiagonalCondition(currentMarker)==true)
		return true;
}

function horizontalCondition(currentMarker) {
	for (i=0;i<3;i++) {
       var count=0;
       for (j=0;j<3;j++) {
          if(document.getElementById("block"+i+j).value===currentMarker)
          	count+=1;
          else {
          	count=0;
          	break;
          }
       }
       if(count===3)
       {
            return true;
            break;
       }
    }
}

function verticalCondition(currentMarker){
	for (i=0;i<3;i++) {
       var count=0;
       for (j=0;j<3;j++) {
          if(document.getElementById("block"+j+i).value===currentMarker)
          	count+=1;
          else {
          	count=0;
          	break;
          }
       }
       if(count===3)
       {
            return true;
            break;
       }
    }
}

function leftDiagonalCondition(currentMarker) {
	var count=0;
	for (i=0;i<3;i++) {
      if(document.getElementById("block"+i+i).value===currentMarker)
      	count+=1;
      else {
      	count=0;
      	break;
      }
    }
   if(count===3)
   {
        return true;
   }
}

function rightDiagonalCondition(currentMarker) {
	var count=0;
	for (i=0,j=2;i<3;i++,j--) {
      if(document.getElementById("block"+i+j).value===currentMarker)
      	count+=1;
      else {
      	count=0;
      	break;
      }
    }
   if(count===3)
   {
        return true;
   }
}

function showResult(currentPlayer){
  document.getElementById("game-board").style.display ="none";
  document.getElementById("game-board").innerHTML="";
  document.getElementById("result-container").style.display ="block";
  if(currentPlayer=='draw')
  {
    document.getElementById("msg").innerHTML="Its A Draw";
    document.getElementById("winner-marker").src = "../images/oops.png";
  }
  else
  {
    document.getElementById("msg").innerHTML="WINSSS!!!!";
    if(currentPlayer==1)
  		document.getElementById("winner-marker").src = "../images/x.png";
  	else
  		document.getElementById("winner-marker").src = "../images/o.png";
  }
}