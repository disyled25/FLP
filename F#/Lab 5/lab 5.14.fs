open System

// This function will traverse all divisors of a number and make some operations with them depending on "f" argument
let Divisors_Traversal n f ini =
    let rec D_T ini i =
        if i = n then f ini i
        elif n % i = 0 then D_T (f ini i) (i+1)
        else D_T ini (i+1)
    D_T ini 1

[<EntryPoint>]
let main args =
    printfn "%A" (Divisors_Traversal 15 (fun x y -> x + y) 0)
    0