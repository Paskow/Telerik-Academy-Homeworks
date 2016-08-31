function solve(numbers) {
    "use strict"
    if (numbers.length === 0) {
        return null;
    } else if (numbers === undefined) {
        throw new Error();
    }

    for (let i = 0; i < numbers.length; i += 1) {
        if (isNaN(numbers[i])) {
            throw new Error();
        } else {
            numbers[i] = +numbers[i];
        }
    }

    return numbers.reduce((a, b) => a + b);
}


module.exports = solve;