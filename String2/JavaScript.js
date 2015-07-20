String.prototype.concatString = function (secondString) {


    var firstString = this;
    var secondString = secondString;
    var concatenatedString = [firstString.length + secondString.length];
    var temp = firstString.length;
    if (temp < secondString.length)
        temp = secondString.length;
    for (var index = 0; index < temp; index++) {
        if (index < firstString.length)
        { concatenatedString[index] = firstString.charAt(index); }
        if (index < secondString.length)
            concatenatedString[index + firstString.length] = secondString.charAt(index);
    }


    concatenatedString = concatenatedString.join("");

    return concatenatedString;

}





String.prototype.Substring = function (numOne, numTwo) {
    if (numOne < 0 || numTwo < 0) {
        document.write("Invalid arguements entered");
        return;
    }
    var str = "";
    for (var index = numOne ; index < numTwo; index++)
    { str = str + (this[index]); }

    return str;
}
