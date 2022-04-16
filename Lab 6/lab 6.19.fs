open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

// Sorts list in order, positive first, then negative
let list_positive_negative_order list = 
    let rec positive list final_list= 
        match list with
        |H::T -> if H > 0 then positive T (final_list@[H]) else positive T final_list
        |[] -> final_list

    let rec negative list final_list = 
        match list with
        |H::T -> if H < 0 then negative T (final_list@[H]) else negative T final_list
        |[] -> final_list

    (positive list [])@(negative list [])

[<EntryPoint>]
let main args = 
    printfn "Minimal even number is %A" (list_positive_negative_order list_input)
    0