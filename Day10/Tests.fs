namespace Day10

module Tests =

    open Day10
    open Xunit

    [<Fact>]
    let ``Parses NoOp as zero`` () =
        let input = "noop";
        let expected = [ 0; ]
        let actual = parseOperation input
        Assert.Equal(expected[0], actual[0])
        Assert.Equal(expected.Length, actual.Length)

    [<Fact>]
    let ``Parses AddX as integer with empty cycle`` () =
        let input = "addx 9000";
        let expected = [ 0; 9000; ]
        let actual = parseOperation input
        Assert.Equal(expected[0], actual[0])
        Assert.Equal(expected[1], actual[1])
        Assert.Equal(expected.Length, actual.Length)

    [<Fact>]
    let ``Parses multiple no op lines as zero`` () =
        let input = [ "noop"; "noop" ]
        let expected = [ 1; 0; 0 ]
        let actual = parseLinesForOperations input
        Assert.Equal(expected[0], actual[0])
        Assert.Equal(expected[1], actual[1])
        Assert.Equal(expected[2], actual[2])

    [<Fact>]
    let ``Parses positive AddX lines as int`` () =
        let input = [ "addx 69" ]
        let expected = [ 1; 0; 69 ]
        let actual = parseLinesForOperations input
        Assert.Equal(expected[0], actual[0])
        Assert.Equal(expected[1], actual[1])
        Assert.Equal(expected[2], actual[2])

    [<Fact>]
    let ``Parses negative AddX lines as int`` () =
        let input = [ "addx -21" ]
        let expected = [ 1; 0; -21 ]
        let actual = parseLinesForOperations input
        Assert.Equal(expected[0], actual[0])
        Assert.Equal(expected[1], actual[1])
        Assert.Equal(expected[2], actual[2])

    [<Fact>]
    let ``Accumulate with last NoOp produces sum times cycle`` () =
        // initial 1
        // Addx 5
        // NoOp
        let input = [ 1; 0; 5; 0; ]
        let cycle = 3
        let expected = 18
        let actual = accumulateUpToCycle input cycle
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Accumulate with last AddX produces sum times cycle`` () =
        // initial 1
        // Addx 6
        let input = [ 1; 0; 6; ]
        let cycle = 1
        let expected = 1
        let actual = accumulateUpToCycle input cycle
        Assert.Equal(expected, actual)
    
    [<Fact>]
    let ``Accumulate with register value 7 multiplies by Cycle`` () =
        // initial 1
        // Addx 6
        let input = [ 1; 0; 6; 0; 0; ]
        let cycle = 4
        let expected = 28
        let actual = accumulateUpToCycle input cycle
        Assert.Equal(expected, actual)
