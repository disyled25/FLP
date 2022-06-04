open System

let MinPrime list = 
    List.min (List.filter (fun x -> x % 2 = 0) list)

[<EntryPoint>]
let main args = 
    printfn "%A" (MinPrime [1;3;5;9;8;20;12;4;5])
    0