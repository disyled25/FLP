open System

// Finds two numbers, maximal and second maximal
let two_max_in_list list = 
    let rec first_max list max1 i index = 
        match list with
        |H::T -> if H > max1 then first_max T H (i + 1) i else first_max T max1 (i + 1) index
        |[] -> (max1, index)

    let rec second_max list (max1,index1) max2 index2 = 
        match list with
        |H::T -> if H <= max1 && H >= max2 && index1 <> index2 then second_max T (max1,index1) H (index2 + 1) else second_max T (max1,index1) max2 (index2 + 1)
        |[] -> (max1, max2)

    second_max list (first_max list list.Head 0 0) list.Head 0

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

[<EntryPoint>]
let main args = 
    let list = list_input;
    printfn "%A" (two_max_in_list list)
    0