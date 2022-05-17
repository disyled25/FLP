open System

// Function that allows the user to enter a list from the console
let list_input =
    let rec l_i list =
        let input = Convert.ToInt32(Console.ReadLine())
        if input = 0 then list
        else l_i (list@[input])
    l_i []

// Counts the numbers in the list that can be obtained by the sum of any two other numbers in this list
let func list =
    let rec funct list0 count ind0 =
        let rec f1 list1 sum ind1 =
            let rec f2 list2 el1 ind2 =
                match list2 with
                | H::T -> if(ind0 <> ind1 && ind0 <> ind2 && ind1 <> ind2 && sum = H + el1) then true else f2 T el1 (ind2+1)
                | [] -> false
            match list1 with
            | H::T -> if (f2 list H 0) then true else f1 T sum (ind1+1)
            | [] -> false
        match list0 with
        | H::T -> funct T (if (f1 list H 0) then (count + 1) else count) (ind0 + 1)
        | [] -> count
    funct list 0 0

[<EntryPoint>]
let main args = 
    let list = list_input
    printfn "%A" (func list)
    0