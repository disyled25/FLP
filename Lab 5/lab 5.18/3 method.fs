open System

//Greatest common divisor function
let rec GC_divisor x y =
    if x = 0 || y = 0 then x + y
        else GC_divisor (if x > y then x % y else x) (if x <= y then y % x else y)
    
//Finds minimal divisor (except 1) of a given number
let rec min_divisor num i = 
    if (num % i) = 0 && i <> 1 then i
        else min_divisor num (i+1)

//Third method function
let rec func3 num = 
    let rec f max i= 
        if i < num then
            if GC_divisor num i <> 1 && i > max && (i % (min_divisor num 1)) <> 0 then f i (i + 1)
                else f max (i + 1)
        else max

    let rec Sum_of_digits num sum pr = 
        if num = 0 then sum
            elif pr num then Sum_of_digits (num / 10) (sum + (num % 10)) pr
                else Sum_of_digits (num / 10) sum pr
        
    (f 1 1) * (Sum_of_digits num 0 (fun x -> (x%10)<5))

[<EntryPoint>]
let main argv =  
    // Print third method
    printfn "%A" (func3 14)
    0