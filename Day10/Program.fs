namespace Day10

module Program =
    open System.IO

    [<EntryPoint>]
    let main _ =

        let lines = File.ReadAllLines("sample-data.txt") |> Array.toList

        let values = lines |> Day10.parseLinesForOperations

        for value: int in values do
            printfn "%d" value

        0
