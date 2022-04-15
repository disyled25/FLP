open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

//  Finds index of last minimal number in list
let index_min_in_list list = 
    let rec list_min list min ind index = 
        match list with
        |H::T -> if H <= min then list_min T H (ind+1) ind else list_min T min (ind+1) index
        |[] -> index
    list_min list list.Head 0 0

// Cuts tail from given index
let cut_tail list index = 
    let rec f list list1 index =
        match list with
        |H::T -> if not (index = 0) then f T (list1@[H]) (index - 1) else list1
        |[] -> list1
    f list [] index 


[<EntryPoint>]
let main args = 
    let list = list_input
    printfn "%A" (cut_tail list (index_min_in_list list))
    0