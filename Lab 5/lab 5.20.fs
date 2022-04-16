open System

// Greater common divisor function
let rec GC_divisor x y =
    if x = 0 || y = 0 then x + y
        else GC_divisor (if x > y then x % y else x) (if x <= y then y % x else y)
    
// Finds minimal divisor of number, except 1 
let min_divisor num = 
    let rec m_d num i = 
        if (num % i) = 0 && i <> 1 then i
            else m_d num (i+1)
    m_d num 1
    
// Checks if number is even or not
let Is_number_even num =
    if num % 2 = 0 then true
        else false

// Checks if number divisible by some int value
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
let rec func1 num = 
    let rec f num ini i =
        if num > ini then
            if (GC_divisor num ini) <> 1 && Is_number_even num then f num (ini + 1) (i + 1)
                else f num (ini + 1) i
        else i
    f num 1 0

    
// Second method
let func2 num = 
    let rec f num max =
        if (num % 10) <> 0 then
            if not (Is_divided_by num 3) && num % 10 > max then f (num / 10) (num % 10)
                else f (num / 10) max
        else max
    f num 0

// Third method
let func3 num = 
    let rec f max i = 
        if i < num then
            if GC_divisor num i <> 1 && i > max && (i % (min_divisor num)) <> 0 then f i (i + 1)
                else f max (i + 1)
        else max
    (f 1 1) * (Sum_of_digits num (fun x -> (x%10)<5))

// Function return tuple that consist of x and y which were typed by user
let Tuple_in =
    let x = Convert.ToInt32(Console.ReadLine())
    let y = Convert.ToInt32(Console.ReadLine())
    (x,y)

// Function will show in console returned value of choosed function 
let Choose_Func tuple = 
    match tuple with
        |(1,y) -> func1 y
        |(2,y) -> func2 y
        |(3,y) -> func3 y
        |anyother -> 0

[<EntryPoint>]
let main argv = 

    Console.WriteLine(Choose_Func(Tuple_in))

    Tuple_in |> Choose_Func |> Console.WriteLine

    0