open System

// Greater common divisor function
let rec GC_divisor x y =
    if x = 0 || y = 0 then x + y
        else GC_divisor (if x > y then x % y else x) (if x <= y then y % x else y)
    
// Finds minimal divisor of number, except 1 
let rec min_divisor num i = 
    if (num % i) = 0 && i <> 1 then i
        else min_divisor num (i+1)
    
// Checks if number is even or not
let Is_number_even num =
    if num % 2 = 0 then true
        else false

// Checks if number divideble by some int value
let Is_divided_by num divisor = 
    if num % divisor = 0 then true
        else false

// Finds sum of digits with condition, if you want to find sum without any condition, use (fun x -> true) as a condition
let Sum_of_digits num pr = 
    let rec sum_of_digits num sum =
        if num = 0 then sum
            elif pr num then sum_of_digits (num / 10) (sum + (num % 10))
                else sum_of_digits (num / 10) sum
    sum_of_digits num 0

// First method
let rec func1 num ini i = 
    if num >= ini then
        if (GC_divisor num ini) <> 1 && Is_number_even num then func1 num (ini + 1) (i + 1)
            else func1 num (ini + 1) i
    else i
    
// Second method
let rec func2 num max = 
    if (num % 10) <> 0 then
        if not (Is_divided_by num 3) && num % 10 > max then func2 (num / 10) (num % 10)
            else func2 (num / 10) max
    else max

// Third method
let rec func3 num = 
    let rec f max i = 
        if i < num then
            if GC_divisor num i <> 1 && i > max && (i % (min_divisor num 1)) <> 0 then f i (i + 1)
                else f max (i + 1)
        else max
    (f 1 1) * (Sum_of_digits num (fun x -> (x%10)<5))

[<EntryPoint>]
let main argv =
    printfn "%A" (func1 6 1 0)
    printfn "%A" (func2 73456 0)
    printfn "%A" (func3 14)
    0