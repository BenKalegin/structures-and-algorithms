module File1

open WordWrapProblem

[<EntryPoint>]
let main argv = 
    let result = solve
    printfn "%A" argv
    0 // return an integer exit code
