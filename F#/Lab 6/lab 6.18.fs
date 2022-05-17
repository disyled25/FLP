open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

// Finds minimal even element in given list of positive integers
// Returns -1 if there is no even numbers in given list of positive integers
let min_even list = 
    let rec m_e list min = 
        match list with
        |H::T -> if H % 2 = 0 && H <= min then m_e T H else m_e T min
        |[] -> min

    let rec find_even list even = 
        match list with
        |H::T -> if H % 2 = 0 then find_even T H else find_even T even
        |[] -> if even % 2 = 0 then even else -1

    m_e list (find_even list list.Head)

[<EntryPoint>]
let main args = 
    printfn "Minimal even number is %A" (min_even list_input)
    0