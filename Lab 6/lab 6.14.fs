open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

//  Counts amount of minimal numbers in list
let count_min_in_list list = 
    let rec found_min list min = 
        match list with
        |H::T -> if H <= min then found_min T H  else found_min T min 
        |[] -> min

    let rec count_min list min count =
        match list with
        |H::T -> if min = H then count_min T min (count+1) else count_min T min count
        |[] -> count
    count_min list (found_min list list.Head) 0


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

// Returns list in between two indexes (including elements with that indexes)
// Example: find_interval_in_list list1 3 8 (returns list of elements in list1 between indexes 3 and 8 including elements with those indexes)
let find_interval_in_list list index1 index2 = 
    cut_tail (cut_head list (index1 - 1)) (index2 - index1 + 1)

[<EntryPoint>]
let main argv = 
    let list = list_input
    printfn "%A" (find_interval_in_list list 3 8)
    printfn "%A" (count_min_in_list (find_interval_in_list list 3 8))
    0