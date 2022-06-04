open System

let f list = 
    let l = [1..List.max list]
    List.except list l

[<EntryPoint>]
let main args = 
    printfn "%A" (f [1;5;4;6;9])
    0
