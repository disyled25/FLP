open System

// Finds greatest common divisor
let rec GC_Divisor x y =
    if x = 0 || y = 0 then x + y
    else 
        let x1 = if x > y then x % y else x
        let y1 = if x <= y then y % x else y
        GC_Divisor x1 y1

// Function from previous lab
let func num f ini = 
    let rec loop num f ini i = 
        if i > num then ini
            elif GC_Divisor num i = 1 then loop num f (f ini i) (i + 1)
                else loop num f ini (i + 1)
    loop num f ini 1

// Euler function
let euler x = func x (fun x y -> x + 1) 0

[<EntryPoint>]
let main args =
    printfn "%A" (euler 9)
    printfn "%A" (GC_Divisor 27 45)
    0