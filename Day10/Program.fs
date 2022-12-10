namespace Day10

module Program =
    open System.IO

    [<EntryPoint>]
    let main _ =

        let lines = File.ReadAllLines("input.txt") |> Array.toList
        let cyclesToCalculate = [ 20; 60; 100; 140; 180; 220; ]
        let solution = Day10.solve lines cyclesToCalculate

        printfn "Solution: %A" solution

        0
