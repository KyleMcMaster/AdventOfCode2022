module Program = 
    let [<EntryPoint>] main args = 

        let getFullyContainsCount (elves: string[][]) = 
            let mutable count = 0;
            // loop each inner item and print
            for pair in elves do
                // split each tuple by dash
                let left = pair.[0].Split('-')
                let right = pair.[1].Split('-')
                //printfn "%s %s %s %s" left.[0] left.[1] right.[0] right.[1]

                if ((int left.[0] <= int right.[0] && int left.[1] >= int right.[1]) 
                    || (int right.[0] <= int left.[0]) && int right.[1] >= int left.[1]) then
                    count <- count + 1
            count

        let getPartiallyContainsCount (elves: string[][]) = 
            let mutable count = 0;

            for pair in elves do
                // split each tuple by dash
                let left = pair.[0].Split('-')
                let right = pair.[1].Split('-')
                
                if ((int left.[0] <= int right.[0] && int right.[0] <= int left.[1])
                || (int right.[0] <= int left.[0] && int left.[0] <= int right.[1])) then
                    count <- count + 1

            count
        
        // read file and print all lines
        let lines = System.IO.File.ReadAllLines("input.txt")
        
        // split each line by comma and store as tuple of strings
        let elves = lines |> Array.map (fun line -> line.Split(','))
        
        let fullyContainsCount = elves |> getFullyContainsCount
        let partiallyContainsCount = elves |> getPartiallyContainsCount

        printfn "fully contains count: %d" fullyContainsCount
        printfn "partially contains count: %d" partiallyContainsCount

        0
