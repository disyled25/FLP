open System

//Greatest common divisor function
let rec GC_divisor x y =
    if x = 0 || y = 0 then x + y
        else GC_divisor (if x > y then x % y else x) (if x <= y then y % x else y)
    
// first method function
let rec func1 num ini i = 
    if num >= ini then
        if (GC_divisor num ini) <> 1 && (ini % 2) = 0 then func1 num (ini + 1) (i + 1)
            else func1 num (ini + 1) i
    else i

[<EntryPoint>]
let main argv =  
    // Print first method
    printfn "%A" (func1 6 1 0)
    0