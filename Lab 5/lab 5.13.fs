open System

let Min_Tail number  =
    let rec M_T number min = 
        if number = 0 then min
        elif number % 10 < min then M_T (number/10) (number%10)
        else M_T (number/10) min
    M_T number (number%10)

let rec Min_Up number = 
    if number = 0 then 9
    elif number % 10 < Min_Up (number/10) then (number%10)
    else Min_Up (number/10)

let Max_Tail number  =
    let rec M_T number max = 
        if number = 0 then max
        elif number % 10 > max then M_T (number/10) (number%10)
        else M_T (number/10) max
    M_T number (number%10)

let rec Max_Up number = 
    if number = 0 then 0
    elif number % 10 > Max_Up (number/10) then (number%10)
    else Max_Up (number/10)

let Mul_Tail number = 
    let rec M_T number mul =
        if number = 0 then mul
        else M_T (number/10) (mul * (number % 10))
    M_T number 1
        
let rec Mul_Up number = 
    if number = 0 then 1
    else (number%10) * Mul_Up (number/10)

[<EntryPoint>]
let main args =
    let x1, x2, x3 = 58152, 462, 821
    printfn "%A, %A, %A, %A, %A, %A" (Min_Up x1) (Min_Tail x1) (Max_Up x2) (Max_Tail x2) (Mul_Up x3) (Mul_Tail x3)
    0