
String.prototype.ConcatString = function () {

    var firstString = this;
    for (var index = 0; index < arguments.length; i++) {
        if (arguments[i] == "null")
            firstString += "null";
        if (arguments[i] == "undefined")
            firstString += "undefined";
        firstString += arguments[i];
    }
    return firstString;

};



String.prototype.Substring = function (numberOne, numberTwo) {
    if (numOne < 0 || numTwo < 0) {
        document.write("Invalid arguements entered");
        return;
    }
    var str = "";
    for (var index = numOne ; index < numTwo; index++)
    { str = str + (this[index]); }

    return str;
}
