open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

// This function will process the list and create a new one consisting of the sum of the three elements of the original list
let func list f =
    let rec funct list list2 =
        if List.length(list) % 3 = 0 then
            match list with
            | a::b::c::T -> funct T (list2@[(f a b c)])
            |[] -> list2
        else funct (list@[1]) list2
    funct list []

[<EntryPoint>]
let main args =
    printfn "%A" (func list_input (fun x y z -> x + y + z))
    0