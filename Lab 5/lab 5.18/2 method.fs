open System

// second method function
let rec func2 num max = 
    if num = 0 then max
        elif (num % 10) % 3 <> 0 && num % 10 > max then func2 (num / 10) (num % 10)
            else func2 (num / 10) max

[<EntryPoint>]
let main argv =  
    // Print second method
    printfn "%A" (func2 973056 0)
    0