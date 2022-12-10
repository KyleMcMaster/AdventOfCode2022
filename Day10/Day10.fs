namespace Day10

module Day10 =

    open System.IO

    let replaceNoOp (line: string) = line.Replace("noop", "")
    let replaceAddX (line: string) = line.Replace("addx", "")
    let trimWhitespace (line: string) = line.Replace(" ", "")

    let parseIntFromOperation (input: string) =
        match input.Substring(0, 4) with
        | "addx" -> input.Substring(4) |> int
        | _ -> 0

    let parseLinesForOperations (lines: string list) = lines |> List.map parseIntFromOperation
