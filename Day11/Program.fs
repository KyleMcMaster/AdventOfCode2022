module Monkeys = // They're bananas!

    type Monkey =
        { id: int
          startingItems: int list // worry levels
          operation: int -> int
          test: int -> int
          totalInspections: int }

    let createMonkey id startingItems operation test =
        { id = id
          startingItems = startingItems
          operation = operation
          test = test
          totalInspections = 0 }

    let sampleMonkeys =
        [ createMonkey
              0
              [ 79; 98 ]
              (fun old -> old * 19)
              (fun x ->
                  match (x % 23) with
                  | 0 -> 2
                  | _ -> 3)
          createMonkey
              1
              [ 54; 65; 75; 74 ]
              (fun old -> old + 6)
              (fun x ->
                  match (x % 19) with
                  | 0 -> 2
                  | _ -> 0)
          createMonkey
              2
              [ 79; 60; 97 ]
              (fun old -> old * old)
              (fun x ->
                  match (x % 13) with
                  | 0 -> 1
                  | _ -> 3)
          createMonkey
              3
              [ 74 ]
              (fun old -> old + 3)
              (fun x ->
                  match (x % 17) with
                  | 0 -> 0
                  | _ -> 1) ]
        |> Array.ofList

    let inputMonkeys =
        [ createMonkey
              0
              [ 96; 60; 68; 91; 83; 57; 85 ]
              (fun old -> old * 2)
              (fun x ->
                  match (x % 17) with
                  | 0 -> 2
                  | _ -> 5)
          createMonkey
              1
              [ 75; 78; 68; 81; 73; 99 ]
              (fun old -> old + 3)
              (fun x ->
                  match (x % 13) with
                  | 0 -> 7
                  | _ -> 4)
          createMonkey
              2
              [ 69; 86; 67; 55; 96; 69; 94; 85 ]
              (fun old -> old + 6)
              (fun x ->
                  match (x % 19) with
                  | 0 -> 6
                  | _ -> 5)
          createMonkey
              3
              [ 88; 75; 74; 98; 80 ]
              (fun old -> old + 5)
              (fun x ->
                  match (x % 7) with
                  | 0 -> 7
                  | _ -> 1)
          createMonkey
              4
              [ 82 ]
              (fun old -> old + 8)
              (fun x ->
                  match (x % 11) with
                  | 0 -> 0
                  | _ -> 2)
          createMonkey
              5
              [ 72; 92; 92 ]
              (fun old -> old * 5)
              (fun x ->
                  match (x % 3) with
                  | 0 -> 6
                  | _ -> 3)
          createMonkey
              6
              [ 74; 61 ]
              (fun old -> old * old)
              (fun x ->
                  match (x % 2) with
                  | 0 -> 3
                  | _ -> 1)
          createMonkey
              7
              [ 76; 86; 83; 55 ]
              (fun old -> old + 4)
              (fun x ->
                  match (x % 5) with
                  | 0 -> 4
                  | _ -> 0) ]
        |> Array.ofList

module Part1 =
    open Monkeys

    let inspectAndDivideByThree (worryLevel: int) operation =
        printfn "Monkey is inspecting item with worry level %i" worryLevel
        let newWorryLevel = worryLevel |> operation
        printfn "Worry level is now %i" newWorryLevel
        let dividedWorryLevel = newWorryLevel / 3
        printfn "Worry level divided by 3 is %i" dividedWorryLevel
        dividedWorryLevel

    let processRound (monkeys: Monkey array) =
        let mutable newMonkeys = monkeys

        for senderId in 0 .. (newMonkeys.Length - 1) do
            let sender = newMonkeys.[senderId]
            printfn "Monkey %A" senderId
            let newInspectionCount = sender.totalInspections + sender.startingItems.Length

            for itemId in 0 .. (sender.startingItems.Length - 1) do
                let worryLevel =
                    inspectAndDivideByThree sender.startingItems.[itemId] sender.operation

                let receiverIndex = sender.test worryLevel
                printfn "Monkey %A is throwing item %A to monkey %A" senderId worryLevel receiverIndex
                let receiver = newMonkeys.[receiverIndex]

                let updatedReceiver =
                    { receiver with startingItems = receiver.startingItems @ [ worryLevel ] }
                newMonkeys.[receiverIndex] <- updatedReceiver

            let updatedSender =
                { sender with
                    totalInspections = newInspectionCount
                    startingItems = [] }
            newMonkeys.[senderId] <- updatedSender

        newMonkeys

    let printMonkeyItems (monkeys: Monkey array) =
        for n in 0 .. (monkeys.Length - 1) do
            let monkey = monkeys.[n]
            printfn "Monkey operationCount %i" monkey.totalInspections
            let itemsAsString = monkey.startingItems |> List.map string |> String.concat "; "
            printfn "Monkey %A: %s items" n itemsAsString

    let printMonkeyInspections (monkeys: Monkey array) =
        for n in 0 .. (monkeys.Length - 1) do
            let monkey = monkeys.[n]
            printfn "Monkey %i inspected items %i times" monkey.id monkey.totalInspections

    let solve (monkeys: Monkey array) =
        let mutable finalMonkeys = monkeys
        let iterations = seq { 1..20 }

        for i in iterations do
            printfn "Round %A" i
            finalMonkeys <- processRound finalMonkeys
        //printMonkeyInspections finalMonkeys
        //printMonkeyItems finalMonkeys

        let twoMostActiveMonkeys =
            finalMonkeys
            |> Array.toList
            |> List.sortByDescending (fun monkey -> monkey.totalInspections)
            |> List.take 2
        printfn "The two most active monkeys are %A and %A" twoMostActiveMonkeys.[0].id twoMostActiveMonkeys.[1].id

        let levelOfMonkeyBusiness =
            twoMostActiveMonkeys
            |> (fun monkeys -> monkeys.[0].totalInspections * monkeys.[1].totalInspections)
        printfn "The level of monkey business is %d" levelOfMonkeyBusiness

module Part2 =
    let solve lines = 0

module Program =
    open Monkeys

    [<EntryPoint>]
    let main args =
        //Part1.solve sampleMonkeys
        Part1.solve inputMonkeys


        0
