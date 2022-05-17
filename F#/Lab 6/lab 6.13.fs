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

//  Finds index of last maximal number in list
let index_max_in_list list = 
    let rec list_max list max ind index = 
        match list with
        |H::T -> if H >= max then list_max T H (ind+1) ind else list_max T max (ind+1) index
        |[] -> index
    list_max list list.Head 0 0

// This function will reverse list 
let reverse_list list =
    let rec rev_l list list1 =
        match list with
        |H::T -> rev_l T list1@[H]
        |[] -> list1
    rev_l list []

// Cuts all elements of list after given index (including element with that index) and return what's left
let cut_tail list index = 
    let rec f list list1 index =
        match list with
        |H::T -> if not (index = 0) then f T (list1@[H]) (index - 1) else list1
        |[] -> list1
    f list [] index 

// Cuts all elements of list before given index (including element with that index) and return what's left
let cut_head list index =
    reverse_list (cut_tail (reverse_list list) (List.length(list) - index - 1))

// Reverse elements in between two indexes
let reverse_between list index1 index2 = 
    let head = cut_tail list (index1 + 1)
    let tail = cut_head list (index2 - 1)
    let body = cut_tail (cut_head list index1) (index2 - index1 - 1)
    head @ (reverse_list(body)) @ tail

[<EntryPoint>]
let main args = 
    let list = list_input 
    let x = index_max_in_list list
    let y = index_min_in_list list
    printfn "%A" (reverse_between list ((fun x y -> if x < y then x else y) x y) ((fun x y -> if x > y then x else y) x y))
    0