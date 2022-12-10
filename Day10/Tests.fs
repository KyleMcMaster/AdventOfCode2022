namespace Day10

module Tests =

    open Day10
    open Xunit

    [<Fact>]
    let ``Parses multiple no op as zero`` () =
        let input = [ "noop"; "noop" ]
        let expected = [ 0; 0 ]
        let actual = parseLinesForOperations input
        Assert.Equal(expected[0], actual[0])
        Assert.Equal(expected[1], actual[1])

    [<Fact>]
    let ``Parses positive AddX as int`` () =
        let input = [ "addx 21" ]
        let expected = [ 21 ]
        let actual = parseLinesForOperations input
        Assert.Equal(expected[0], actual[0])

    [<Fact>]
    let ``Parses negative AddX as int`` () =
        let input = [ "addx -21" ]
        let expected = [ -21 ]
        let actual = parseLinesForOperations input
        Assert.Equal(expected[0], actual[0])
