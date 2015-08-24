"use strict";
String.prototype.Substring = function (numOne, numTwo) {

    if (numOne<0 || numOne == null)
        numOne = 0;

    else if(numTwo<0 || numTwo == null)
        numTwo = 0;
    
    if (numTwo<numOne) 
        {
            var temp = numOne;
            numOne=numTwo;
            numTwo= temp;
        }

    if (numOne == null && numTwo == null)
        return this;

    if (numOne == numTwo || (numOne == undefined && numTwo == undefined) || (numOne > this.length && numTwo > this.length))
        return "";
    
    if ( numTwo > this.length || numTwo == undefined)
        {
            numTwo = this.length;
        }
        
    var str = "";
    for (var index = numOne ; index < numTwo; index++)
        { 
            str = str + (this[index]);
        }
    return str;
            
    
};