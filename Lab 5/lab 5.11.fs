open System
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

[<EntryPoint>]
let main argv =
    Console.WriteLine("What is your favorite programming language?")
    let user_answer = Console.ReadLine()
    printfn "%A" (question user_answer)
    0