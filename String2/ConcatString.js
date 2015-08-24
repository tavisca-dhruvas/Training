"use strict";
String.prototype.ConcatString = function () {

    var firstString = this;
    for (var index = 0; index < arguments.length; i++) {
        if (arguments[index] == "null")
            firstString += "null";
        if (arguments[index] == "undefined")
            firstString += "undefined";
        firstString += arguments[index];
    }
    return firstString;

};



