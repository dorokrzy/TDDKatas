describe("RomanNumeralsparser", function () {

    var parser;
    
    beforeEach(function () {
        parser = new RomanNumeralsConverter();
    });

    it("should convert 1 to a roman number", function () {
        var number = parser.convert(1);
        expect(number).toEqual("I");
    });

    it("should convert 2 to a roman number", function () {
        var number = parser.convert(2);
        expect(number).toEqual("II");
    });

    it("should convert 3 to a roman number", function () {
        var number = parser.convert(3);
        expect(number).toEqual("III");
    });

    it("should convert 4 to a roman number", function () {
        var number = parser.convert(4);
        expect(number).toEqual("IV");
    });

    it("should convert 5 to a roman number", function () {
        var number = parser.convert(5);
        expect(number).toEqual("V");
    });

    it("should convert 6 to a roman number", function () {
        var number = parser.convert(6);
        expect(number).toEqual("VI");
    });

    it("should convert 7 to a roman number", function () {
        var number = parser.convert(7);
        expect(number).toEqual("VII");
    });

    it("should convert 8 to a roman number", function () {
        var number = parser.convert(8);
        expect(number).toEqual("VIII");
    });

    it("should convert 9 to a roman number", function () {
        var number = parser.convert(9);
        expect(number).toEqual("IX");
    });

    it("should convert 10 to a roman number", function () {
        var number = parser.convert(10);
        expect(number).toEqual("X");
    });

    it("should convert 13 to a roman number", function () {
        var number = parser.convert(13);
        expect(number).toEqual("XIII");
    });

    it("should convert 19 to a roman number", function () {
        var number = parser.convert(19);
        expect(number).toEqual("XIX");
    });

    it("should convert 29 to a roman number", function () {
        var number = parser.convert(29);
        expect(number).toEqual("XXIX");
    });
    
    it("should convert 30 to a roman number", function () {
        var number = parser.convert(30);
        expect(number).toEqual("XXX");
    });

    it("should convert 34 to a roman number", function () {
        var number = parser.convert(34);
        expect(number).toEqual("XXXIV");
    });

    it("should convert 40 to a roman number", function () {
        var number = parser.convert(40);
        expect(number).toEqual("XL");
    });

    it("should convert 45 to a roman number", function () {
        var number = parser.convert(45);
        expect(number).toEqual("XLV");
    });

    it("should convert 49 to a roman number", function () {
        var number = parser.convert(49);
        expect(number).toEqual("XLIX");
    });

    it("should convert 50 to a roman number", function () {
        var number = parser.convert(50);
        expect(number).toEqual("L");
    });

    it("should convert 90 to a roman number", function () {
        var number = parser.convert(90);
        expect(number).toEqual("XC");
    });

    it("should convert 96 to a roman number", function () {
        var number = parser.convert(96);
        expect(number).toEqual("XCVI");
    });
    
    it("should convert 100 to a roman number", function () {
        var number = parser.convert(100);
        expect(number).toEqual("C");
    });
    
    it("should convert 214 to a roman number", function () {
        var number = parser.convert(214);
        expect(number).toEqual("CCXIV");
    });

    it("should convert 596 to a roman number", function () {
        var number = parser.convert(596);
        expect(number).toEqual("DXCVI");
    });

    it("should convert 990 to a roman number", function () {
        var number = parser.convert(990);
        expect(number).toEqual("CMXC");
    });
});