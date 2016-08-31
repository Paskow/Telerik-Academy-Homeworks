function solve(firstNumber, secondNumber) {
    "use strict"

    if (isNaN(firstNumber) || isNaN(secondNumber)) {
        throw new Error();
    }

    var primeNumbers = [];
    for (let i = +firstNumber; i <= +secondNumber; i += 1) {
        for (let j = 1; j < i; j += 1) {
            if (i % j === 0 && j !== 1) {
                break;
            }
            if ((i % j !== 0 || j === 1) && j === i - 1) {
                primeNumbers.push(i);
            }
        }
    }

    return primeNumbers;
}

module.exports = solve;