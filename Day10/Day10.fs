namespace Day10

module Day10 =

    let parseOperation (input: string) =
        let emptyList = [ 0 ]
        match input.Substring(0, 4) with
            | "addx" -> List.append emptyList [ input.Substring(4) |> int ]
            | "noop" -> [ 0 ]
            | _ -> [ 0 ]
    
    let parseLinesForOperations (lines: string list) = 
        let initialList = [ 1 ]
        let operationValues = List.map parseOperation lines
        
        // operationValues |> List.iter (fun x -> (ret <- (List.concat [ ret; x; ])))
        let ret = operationValues |> List.reduce (fun x y -> List.concat [ x; y; ])

        List.concat [ initialList; ret; ]

    let accumulateUpToCycle (list: int list) cycle =
        let subsection = List.take (cycle + 1) list

        let isNoOp = List.last subsection = 0 

        let accumulate list =        
            list
            |> List.sum
            |> (*) (cycle)

        match isNoOp with
            | true -> accumulate subsection 
            | false -> subsection |> List.take (subsection.Length - 1) |> accumulate

    let solve operations cyclesThatICareAbout =
        let operationValues = operations |> parseLinesForOperations

        cyclesThatICareAbout 
            |> List.map (accumulateUpToCycle operationValues)
            |> List.sum
