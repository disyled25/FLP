open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

// Checks if given list contains elements from given segment and returns them
let segment_elements list segment = 
    let rec s_e list final_list = 
        match list with
        |H::T -> if List.contains H segment then s_e T (final_list@[H]) else s_e T (final_list)
        |[] -> final_list
    s_e list []

[<EntryPoint>]
let main args = 
    let segment = [5; 6; 7; 8]
    printfn "%A" (segment_elements list_input segment)
    0