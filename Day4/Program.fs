module Program = 
    let [<EntryPoint>] main args = 
        
        // read file and print all lines
        let lines = System.IO.File.ReadAllLines("input.txt")

        // // print total pairs
        printfn "Total lines: %d" lines.Length
        
        // split each line by comma and store as tuple of strings
        let pairs = lines |> Array.map (fun line -> line.Split(','))

        printfn "Total pairs: %d" pairs.Length

        let mutable count = 0;
        // loop each inner item and print
        for pair in pairs do
            // split each tuple by dash
            let left = pair.[0].Split('-')
            let right = pair.[1].Split('-')
            printfn "%s %s %s %s" left.[0] left.[1] right.[0] right.[1]

            // if left 0 greater than right 0 
            // or left 0 equals right 0 and left 1 greater than right 1
            // then increment count
            if ((int left.[0] <= int right.[0] && int left.[1] >= int right.[1]) 
                || (int right.[0] <= int left.[0]) && int right.[1] >= int left.[1]) then
                count <- count + 1
                printfn "fully contains!"

        printfn "count: %d" count

        0
