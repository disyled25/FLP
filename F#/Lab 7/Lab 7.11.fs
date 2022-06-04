open System

let rec f list1 list2 count = 
    match list1 with
        |H::T -> if List.contains H list2 then f T list2 (count + 1) else f T list2 count
        |[] -> count

[<EntryPoint>]
let main args =
    let list1 = [1;5;2;4;6;7;2]
    let list2 = [1;4;6;9;0;11;3]
    printf "%A" (f list1 list2 0)
    0