open System

let IsLocalMax list index= 
    let Max = List.item index list
    if  (List.item (index - 1) list < Max) && (List.item (index + 1) list < Max) then true else false

[<EntryPoint>]
let main args = 
    printfn "%A" (IsLocalMax [1;3;5;9;8;20;12;4] 3)
    0