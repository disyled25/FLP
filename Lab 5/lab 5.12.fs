open System

[<EntryPoint>]

let main args = 
    let question user_answer =
        match user_answer with
            | "F#" | "Prolog" -> "Sycophant"
            | "C++" | "Python" -> "Kinda basic"
            | "C" | "Pascal" -> "You're a dinosaur"
            | "Java" -> "Do you make mods for Minecraft?"
            | "C#" -> "Unity developer right here"
            | "Rust" | "Perl" | "Ruby" -> "Are you even exist?"
            | "JavaScript" -> "Are you misspelled Java?"
            | others -> "Didn't expect that"

    Console.WriteLine("What is your favorite programming language?")

    // superposition
    (Console.ReadLine >> question >> printfn "%s") ()

    // currying
    let answer input (output:string -> unit) choose = output(choose(input()))
    answer Console.ReadLine Console.WriteLine question
    0