// Finds greatest common divisor
let rec GC_Divisor x y =
    if x = 0 || y = 0 then x + y
    else 
        let x1 = if x > y then x % y else x
        let y1 = if x <= y then y % x else y
        GC_Divisor x1 y1

//Divisors traversal
let func1 num f ini pr = 
    let rec loop ini i = 
        if i > num then ini
            elif num % i = 0 && pr i then loop (f ini i) (i + 1)
                else loop ini (i + 1)
    loop ini 1

//Coprime numbers traversal
let func2 num f ini pr = 
    let rec loop ini i = 
        if i > num then ini
            elif GC_Divisor num i = 1 && pr i then loop (f ini i) (i + 1)
                else loop ini (i + 1)
    loop ini 1

[<EntryPoint>]
let main args =
    printfn "%A" ( func1 9 ( fun x y -> x + y ) 0 ( fun x -> x > 5 ) )
    printfn "%A" ( func2 9 ( fun x y -> x + y ) 0 ( fun x ->  x % 2 = 1 ) )
    0