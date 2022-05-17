open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

// Count all even numbers in given list
let count_even_in_list list = 
    let rec count_even list count =
        match list with
        |H::T -> if H % 2 = 0 then count_even T (count + 1) else count_even T count
        |[] -> count
    count_even list 0


[<EntryPoint>]
let main args = 
    printfn "\nThere is %A even numbers in list" (count_even_in_list list_input)
    0