open System

//Greatest common divisor function
let rec GC_divisor x y =
    if x = 0 || y = 0 then x + y
        else GC_divisor (if x > y then x % y else x) (if x <= y then y % x else y)
    
// first method function
let rec func1 num i ini = 
    if num > i then
        if (GC_divisor num i) <> 1 && (i % 2) = 0 then func1 num (i + 1) (ini + 1)
            else func1 num (i + 1) ini
    else ini

[<EntryPoint>]
let main argv =  
    // Print first method
    printfn "%A" (func1 6 1 0)
    0