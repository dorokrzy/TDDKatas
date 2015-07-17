function RomanNumeralsConverter() {

    var self = this;

    var baseLetters = ["M","D","C", "L", "X", "V", "I"];
    var baseNumbers = [1000, 500, 100, 50, 10, 5, 1];
       

    function getRomanNumber(decimalNumber) {

        return getRomanNumberPart(decimalNumber, baseLetters, baseNumbers, 0, 1);
    }


    function getRomanNumberPart(decimalNumber, letters, numbers, currentLetterIndex) {

        var division = Math.floor(decimalNumber / numbers[currentLetterIndex]);
        var remainder = decimalNumber % numbers[currentLetterIndex];

        console.log("currB:" + letters[currentLetterIndex] + " division: " + division + "remainder: " + remainder);

        if (division <= 3) {
            var number = "";
            for (var j = 0; j < division; j++)
                number = number + letters[currentLetterIndex];

            if (remainder == 0) {
                return number;
            }

            return number + getRomanNumberPart(decimalNumber - division * numbers[currentLetterIndex], letters, numbers, currentLetterIndex + 1);
        }

        if (division == 4) {

            if (remainder % 4 == 0 && decimalNumber % numbers[currentLetterIndex - 1] % 9 == 0) {
                console.log("hrere");
                return letters[currentLetterIndex + 1] + letters[currentLetterIndex - 1];
                //   + getRomanNumberPart(decimalNumber - division * numbers[currentLetterIndex], letters, numbers, currentLetterIndex + 1);
            }

            var number2 = letters[currentLetterIndex] + letters[currentLetterIndex - 1];

            if (remainder == 0)
                return number2;
            else
                return number2 + getRomanNumberPart(decimalNumber - division * numbers[currentLetterIndex], letters, numbers, currentLetterIndex + 1);
        }

        return "NAN";
    }

    self.convert = function(decimalNumber) {
        return getRomanNumber(decimalNumber);
    };
}

